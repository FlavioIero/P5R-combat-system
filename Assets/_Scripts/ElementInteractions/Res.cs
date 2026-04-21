using System;
using UnityEngine;


[Serializable]
public class Res : ElementInteraction
{
    [SerializeField, Range(0f, 0.999f)] private float _resistancePrctg = 0.5f;
    [SerializeField, Min(0f)] private int _resistanceFlat = 0;

    public override SkillContext ProcessIncomingAttack(SkillContext context)
    {
        var atk = context.AttackData;
        int reduction = (int)(atk.Damage * _resistancePrctg) + _resistanceFlat;

        context.AttackData.Damage -= Math.Min(atk.Damage, reduction);

        return context;
    }
}
