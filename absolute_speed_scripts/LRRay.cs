using UnityEngine;

/// <summary>車の左右から照射するレイの管理クラス</summary>
public class LRRay
{
    private readonly Transform mTransform;
    /// <summary>レイの設定</summary>
    private readonly RayConfig.LRRayConfig mRayConfig;
    /// <summary>右方向</summary>
    private Vector3 RTo { get { return mTransform.right; } }
    /// <summary>左方向</summary>
    private Vector3 LTo { get { return -mTransform.right; } }



    public LRRay(Transform transform, RayConfig.LRRayConfig rayConfig) { mTransform = transform; mRayConfig = rayConfig; }



    /// <summary>右方向ボックスキャスト</summary>
    public bool RBoxRay(out RaycastHit hitInfo)
    {
        Vector3 harfSize = mRayConfig.BoxcastSize / 2.0f;
        Vector3 from = RayMethod.MakeFrom(mTransform, mRayConfig.CenterOffset);
        return Physics.BoxCast(from, harfSize, RTo, out hitInfo, mTransform.rotation, mRayConfig.LrLength);
    }



    /// <summary>左方向ボックスキャスト</summary>
    public bool LBoxRay(out RaycastHit hitInfo)
    {
        Vector3 harfSize = mRayConfig.BoxcastSize / 2.0f;
        Vector3 from = RayMethod.MakeFrom(mTransform, mRayConfig.CenterOffset);
        return Physics.BoxCast(from, harfSize, LTo, out hitInfo, mTransform.rotation, mRayConfig.LrLength);
    }



    public void DrawRayGizmos()
    {
        Gizmos.color = Color.red;
        if (mRayConfig == null) { return; }
        RaycastHit hitInfo;
        RBoxRay(out hitInfo);
        Gizmos.DrawWireCube(RayMethod.MakeFrom(mTransform, mRayConfig.CenterOffset) + (RTo * (hitInfo.distance <= 0f ? mRayConfig.LrLength : hitInfo.distance)), mRayConfig.BoxcastSize);
        LBoxRay(out hitInfo);
        Gizmos.DrawWireCube(RayMethod.MakeFrom(mTransform, mRayConfig.CenterOffset) + (LTo * (hitInfo.distance <= 0f ? mRayConfig.LrLength : hitInfo.distance)), mRayConfig.BoxcastSize);
    }
}
