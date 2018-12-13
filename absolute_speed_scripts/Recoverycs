using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System.Threading.Tasks;

public struct RecoveryData
{
    /// <summary>位置情報</summary>
    private Vector3 mPosition;
    /// <summary>回転情報</summary>
    private Quaternion mRotation;
    /// <summary>位置情報</summary>
    public Vector3 Position { get { return mPosition; } set { mPosition = value; } }
    /// <summary>回転情報</summary>
    public Quaternion Rotation { get { return mRotation; } set { mRotation = value; } }
    public RecoveryData(Vector3 position, Quaternion rotation) { mPosition = position; mRotation = rotation; }
}

public class Recovery : MonoBehaviour
{
    /// <summary>何秒前に戻るのか</summary>
    private static float RECOVERY_TIME = 3.0f;
    /// <summary>現在のゲームシーンを確認するクラス</summary>
    private GameSceneManager mGameSceneManager;
    /// <summary>現在のゲームステートを確認するクラス</summary>
    private GameStateManager mGameStateManager;
    /// <summary>リプレイ用クラス</summary>
    private RePlayer mRePlayer;
    /// <summary>プレイヤのRigidbody</summary>
    private Rigidbody mRigidbody;
    /// <summary>フェードを管理するクラス</summary>
    private FadeManager mFadeManager;



    private void Awake()
    {
        mGameSceneManager = FindObjectOfType<GameSceneManager>();
        mGameStateManager = FindObjectOfType<GameStateManager>();
        mRePlayer = GetComponent<RePlayer>();
        mRigidbody = GetComponent<Rigidbody>();
        mFadeManager = FindObjectOfType<FadeManager>();

        this.UpdateAsObservable()
            .Where(x => Input.GetKeyDown(KeyCode.F5) || Input.GetKeyDown(KeyCode.Escape))
            .Subscribe(async x =>
          {
              if (mGameSceneManager.SceneState != SceneState.GAME) { return; }
              if (mGameStateManager.CurrentGameState.Value != InGameState.PLAY) { return; }
              if (gameObject.name == ConstString.Name.PLAYER) { await FadeRecovery(); }
              else { Recovery(); }
          });
    }



    /// <summary>
    /// リカバリする際に画面をフェードさせる
    /// </summary>
    /// <returns></returns>
    private async Task FadeRecovery()
    {
        await mFadeManager.FadeInStart(0.5f);

        Recovery();

        await mFadeManager.FadeOutStart(0.5f);
    }



    /// <summary>
    /// プレイヤの位置を指定秒数時点まで戻す
    /// リプレイクラスにある移動情報を更新する
    /// </summary>
    private void Recovery()
    {
        RecoveryData data = mRePlayer.InsertRecovery();
        transform.position = data.Position;
        transform.rotation = data.Rotation;
        mRigidbody.velocity = Vector3.zero;
    }



    /// <summary>
    /// intervalから戻るフレーム数を算出する
    /// </summary>
    /// <returns>The recovery index.</returns>
    /// <param name="interval">Interval.</param>
    public static int CalcRecoveryIndex(float interval)
    {
        return (int)(RECOVERY_TIME / interval);
    }
}
