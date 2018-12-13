using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤ以外でリプレイを使用したい場合に用いるクラス
/// </summary>
public class RePlayer : MonoBehaviour
{

    /// <summary>リプレイクラス</summary>
    private RePlayCalc mRePlayCalc;
    /// <summary>ゲームシーン管理クラス</summary>
    private GameSceneManager mGameSceneManager;
    /// <summary>初期位置</summary>
    private RecoveryData mInitialPosRot;
    /// <summary>自身のRigidbody</summary>
    private Rigidbody mRigidbody;
    /// <summary>再生開始フラグ</summary>
    private bool mStartRePlay;
    /// <summary>再再生フラグ</summary>
    private bool ReRePlay = false;
    /// <summary>移動情報を保存する間隔</summary>
    private float mInterval = 0.1f;



    private void Awake()
    {
        mRigidbody = GetComponent<Rigidbody>();
        mGameSceneManager = FindObjectOfType<GameSceneManager>();
        mRePlayCalc = new RePlayCalc(transform, mInterval);
        mInitialPosRot.Position = transform.position;
        mInitialPosRot.Rotation = transform.rotation;
    }



    private void Update()
    {
        mRePlayCalc.UpdateRec();
        if (mStartRePlay)
        {
            mRigidbody.velocity = Vector3.zero;
            mRePlayCalc.UpdateRePlay();
        }

        if (ReRePlay)
        {
            mRigidbody.velocity = Vector3.zero;
            mRePlayCalc.ReRePlay();
            ReRePlay = false;
        }
    }



    //1回だけ呼ぶ
    public void Replay()
    {

        if (mGameSceneManager.SceneState == SceneState.GAME)//再録画処理
        {
            mStartRePlay = false;
            mRePlayCalc.ReRec();
            transform.SetPositionAndRotation(mInitialPosRot.Position, mInitialPosRot.Rotation);//rank trackerとinitializerの座標初期化処理より遅くメソッドが呼ばれるため、ここで初期化する
        }
        else if (mGameSceneManager.SceneState == SceneState.REPLAY) { mStartRePlay = true; }
    }



    public void ReReplay()
    {
        if (mGameSceneManager.SceneState == SceneState.GAME) { ReRePlay = false; }
        else if (mGameSceneManager.SceneState == SceneState.REPLAY) ReRePlay = true;
    }



    /// <summary>
    /// リプレイクラスにある移動情報を更新する
    /// </summary>
    /// <returns></returns>
    public RecoveryData InsertRecovery()
    {
        return mRePlayCalc.InsertRecovery();
    }
}
