using UnityEngine;

public class WallHitCheck
{
    /// <summary>左右のレイ管理クラス</summary>
    private LRRay mLRRay;
    /// <summary>レイの衝突情報</summary>
    private RaycastHit hitInfo;



    /// <summary>左側の衝突フラグ</summary>
    public bool LHit { get { return mLRRay.LBoxRay(out hitInfo); } }
    /// <summary>右側の衝突フラグ</summary>
    public bool RHit { get { return mLRRay.RBoxRay(out hitInfo); } }
    /// <summary>左右どちらかのレイが当たった場合true</summary>
    public bool LOrRHit { get { return LHit || RHit; } }



    public WallHitCheck(Transform transform, RayConfig.LRRayConfig rayConfig)
    {
        mLRRay = new LRRay(transform, rayConfig);
    }
}