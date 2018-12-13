using UnityEngine;

/// <summary>壁衝突回避クラス</summary>
public class DirectionFix
{
    private Transform mTransform;
    /// <summary>方向修正用レイクラス</summary>
    private DirectionFixRay mFixRay;



    public DirectionFix(Transform transform, RayConfig.DirectionFixRayConfig conf)
    {
        mTransform = transform;
        mFixRay = new DirectionFixRay(transform, conf);
    }



    /// <summary>壁に衝突したときの方向修正補助処理</summary>
    public void FixDirection(float accel, float steer)
    {
        RaycastHit hitInfo;
        bool hit = mFixRay.ForwardBoxCast(out hitInfo);
        if (!hit) { return; }
        if (accel < 0.2f) { return; }
        //衝突している場合
        mTransform.Rotate(0.0f, 0.9f * steer, 0.0f);
    }
}
