using System;
using UnityEngine;


[Serializable]
public class Abs : ElementInteraction
{
    [SerializeField, Range(0f, 1f)] private float _absorptionPrctg = 0.5f;
    [SerializeField, Min(0f)] private int _absorptionFlat = 0;

    public override SkillContext ProcessIncomingAttack(SkillContext context)
    {
        var dmg = context.AttackData.Damage;

        context.HealData.HealAmount += Mathf.Min(dmg, (int)(dmg * _absorptionPrctg) + _absorptionFlat);
        context.AttackData.Damage = 0;
        // probably useless
        context.AttackData.Absorbed = true;

        context.Target.Heal(context.HealData);

        return context;
    }
}
