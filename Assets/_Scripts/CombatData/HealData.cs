using System;
using UnityEngine;


[Serializable]
public class HealData
{
    [Min(0)] public int HealAmount = 0;

    public HealData Clone()
    {
        var healData = new HealData();
        healData.HealAmount = HealAmount;

        return healData;
    }
}
