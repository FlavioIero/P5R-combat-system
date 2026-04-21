using System;
using UnityEngine;


[Serializable]
public class Weak : ElementInteraction
{
    [SerializeField, Range(0f, 1f)] private float _additionalDmgPrctg = 0.5f;
    [SerializeField, Min(0f)] private int _additionalDmgFlat = 0;

    public override SkillContext ProcessIncomingAttack(SkillContext context)
    {
        var atk = context.AttackData;
        context.AttackData.Damage += (int)(atk.Damage * _additionalDmgPrctg) + _additionalDmgFlat;

        return context;
    }
}
