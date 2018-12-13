using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GearData
{
    [SerializeField, Tooltip("要素名")]
    private string mIndexName;
    [SerializeField, Tooltip("設定するギア")]
    private GearState mGear;
    [SerializeField, Tooltip("ギア変更に必要な速度")]
    private float mNeedSpeed = 0.0f;
    [SerializeField, Tooltip("ギアで出せる最大速度")]
    private float mMaxSpeed = 0.0f;
    [SerializeField, Range(0, 100), Tooltip("アクセルを踏んでいないときの逓減速度")]
    private float mEngineBrake = 0.0f;
    [SerializeField, Range(0, 50), Tooltip("アクセルをべた踏みしたとき、1秒間に時速何km上げるか")]
    private float mEngineRps = 0.0f;



    /// <summary>設定するギア</summary>
    public GearState Gear { get { return mGear; } }
    /// <summary>ギア変更に必要な速度</summary>
    public float NeedSpeed { get { return ConvertUnits.KmphToMps(mNeedSpeed); } }
    /// <summary>ギアで出せる最大速度</summary>
    public float MaxSpeed { get { return ConvertUnits.KmphToMps(mMaxSpeed); } }
    /// <summary>エンジンブレーキの強さ</summary>
    public float EngineBrake { get { return mEngineBrake; } }
    /// <summary>毎秒の回転数上昇量</summary>
    public float EngineRot { get { return mEngineRps; } }
}