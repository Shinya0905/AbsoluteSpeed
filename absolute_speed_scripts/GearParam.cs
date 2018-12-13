using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// ギアデータの管理クラス
/// </summary>
[CreateAssetMenu(menuName = "GearParam", fileName = "GearParam")]
public class GearParam : ScriptableObject
{
    [SerializeField]
    private GearData[] mGearDataBase = new GearData[8];



    /// <summary>
    /// 現在のギアのステートに合ったギアのデータを取得する
    /// </summary>
    /// <param name="gearState"></param>
    /// <returns></returns>
    public GearData GetGearData(GearState gearState)
    {
        return mGearDataBase.FirstOrDefault(value => value.Gear == gearState);
    }
}


