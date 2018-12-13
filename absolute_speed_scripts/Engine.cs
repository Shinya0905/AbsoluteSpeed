using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System.Linq;

/// <summary>
/// エンジン
/// </summary>
public class Engine
{
    /// <summary>エンジン回転数</summary>
    private float mEngineSpeed = 0.0f;
    /// <summary>エンジンで求める速度の計算処理</summary>
    private EngineSpeedCalc mEngineCalc = null;
    /// <summary>車のrigidbody</summary>
    private Rigidbody mRigidbody;
    /// <summary>transmission取得</summary>
    private IGearManageable mGearManager;



    /// <summary>エンジンの回転数</summary>
    public float GetEngineSpeed { get { return mEngineSpeed; } }
    /// <summary>エンジン回転数をセットする</summary>
    public float EngineSpeed    { set { mEngineSpeed = value; } }



    public Engine(EngineSpeedCalc engineCalc, Rigidbody rigidbody, IGearManageable input, IReadOnlyReactiveProperty<GearState> gear)
    {
        mEngineCalc = engineCalc;
        mRigidbody = rigidbody;
        mGearManager = input;

        gear
    .Buffer(2, 1)
    .Subscribe(x =>
    {
        //現在のギアデータ
        GearState currentGear = x.Last();
        //1つ前のギアデータ
        GearState preGear = x.First();


        //atの時ギアが下がった時に速度が少し下がる処理
        //mtの時度外視
        if (input.GetGearManager.IsMT) { return; }
        //Rの時は度外視
        if (currentGear == GearState.REVERSE) { return; }
        if (preGear == GearState.REVERSE) { return; }
        //ギアが下げられた場合
        if ((int)currentGear < (int)preGear) { mEngineSpeed -= 5.0f; }
    });
    }



    /// <summary>
    /// 回転数を増やす処理
    /// エンジン回転数を返す
    /// ■accel      :アクセルのインプット
    /// ■brake      :ブレーキのインプット
    /// ■currentGear:現在のギアステート
    /// </summary>
    public float UpdateRotateEngine(float accel, float brake, GearState currentGear)
    {
        if (mGearManager.GetGearManager.IsMT)//mt時
        {
            if ((currentGear != GearState.REVERSE) && (mEngineSpeed > 0.0f)) { mEngineSpeed = mRigidbody.velocity.magnitude; }

            //エンジン回転数の計算処理
            mEngineSpeed = mEngineCalc.CalcEngineSpeed(mEngineSpeed, accel);
            //スタートダッシュの回転数加工処理
            mEngineSpeed = mEngineCalc.AccelarateStart(accel, mEngineSpeed, currentGear);
            //ブレーキ処理
            mEngineSpeed = mEngineCalc.Brake(brake, mEngineSpeed);
            return mEngineSpeed;
        }
        else
        {
            if (currentGear != GearState.REVERSE) { mEngineSpeed = mRigidbody.velocity.magnitude; }
            mEngineSpeed = mEngineCalc.CalcEngineSpeedAT(mEngineSpeed, accel, brake);
            mEngineSpeed = mEngineCalc.AccelarateStart(accel, mEngineSpeed, currentGear);
            mEngineSpeed = mEngineCalc.BrakeAT(brake, mEngineSpeed);
            return mEngineSpeed;
        }
    }



    /// <summary>
    /// 衝突している状態のとき、エンジン回転数が上がらないようにする処理
    /// </summary>
    public void OnCollisionStay()
    {
        if (mEngineSpeed < 0.0f)
        {
            mEngineSpeed = Mathf.Clamp(mEngineSpeed, -5.8f, Mathf.Infinity);
        }
    }



    /// <summary>
    /// 壁に衝突したときの速度低減処理
    /// ■isHit:衝突しているか
    /// </summary>
    public void GiveWallPenalty(bool isHit) { mEngineCalc.GiveWallPenalty(isHit); }



    /// <summary>
    /// ドリフト時の速度低減処理
    /// ■isDrift:ドリフトしているか
    /// ■forward:正面方向ベクトル
    /// </summary>
    /// <param name="isDrift"></param>
    /// <param name="forward"></param>
    public void GiveDriftPenalty(bool isDrift, Vector3 forward)
    {
        if (!isDrift) { return; }
        mEngineCalc.GiveDriftPenalty(isDrift, Vector3.Angle(mRigidbody.velocity, forward));
    }



    /// <summary>
    /// AIと衝突したときの速度低減処理
    /// ■isCollision:衝突しているか
    /// </summary>
    /// <param name="isCollision"></param>
    public void GiveAiPenalty(bool isCollision) { mEngineCalc.GiveAiPenalty(isCollision); }



    /// <summary>
    /// エンジン回転数を取得する
    /// ■engineSpeed:速度
    /// </summary>
    /// <param name="engineSpeed"></param>
    /// <returns></returns>
    public float GetEngineRpm(float engineSpeed) { return mEngineCalc.GetEngineRpm(mEngineSpeed); }
}
