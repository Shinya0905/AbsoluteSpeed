using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;


/// <summary>
/// 表示用エンジン回転数の計算クラス
/// </summary>
public class EngineRpmCalculator
{
    /// <summary>表示用エンジン回転数の最大値</summary>
    private const float MAX_ENGINE_RPM = 8000.0f;
    /// <summary>ギアで設定された最大エンジン回転数</summary>
    private float mMaxSpeed = 0.0f;
    /// <summary>1フレーム前の最大エンジン回転数</summary>
    private float mMaxPreSpeed = 0.0f;
    /// <summary>現在のギア</summary>
    private GearState mGearState;



    //コンストラクタ
    public EngineRpmCalculator(GearParam gearParam, IReadOnlyReactiveProperty<GearState> gearState)
    {
        gearState
            .Buffer(2, 1)
            .Subscribe(x =>
        {
            //現在のギアに設定されている最高速度
            mMaxSpeed = gearParam.GetGearData(x.Last()).MaxSpeed;
            //現在のギアステート
            mGearState = x.Last();
            //ひとつ前のギアに設定されている最高速度
            mMaxPreSpeed = gearParam.GetGearData(x.First()).MaxSpeed;
        });
    }



    /// <summary>
    /// エンジン回転数を計算する処理
    /// ■speed:車の速度
    /// </summary>
    /// <param name="speed"></param>
    /// <returns></returns>
    public float CalcEngineRpm(float speed)
    {

        float max = 0.0f;
        if(mGearState == GearState.NEUTRAL) { max = mMaxPreSpeed; }
        else { max = mMaxSpeed; }
        //現在の速度と現在の最大回転数の比を出す
        //float rate = speed * GetCoeff(mGearState) / mMaxSpeed;
        float rate = speed / max;

        if (mGearState == GearState.NEUTRAL) { rate = 0.0f; }
        //比から表示用の回転数を求める
        //float rpm = rate * GetInnerMaxRot(mGearState);
        float rpm = rate;
        rpm = Mathf.Clamp(rpm, 0.0f, MAX_ENGINE_RPM);
        return rpm;

    }
}