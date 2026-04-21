using System;
using UnityEngine;


namespace Skills.Effects
{
    [Serializable, Tooltip("Adds or removes from AttackData")]
    public class SE_ModifyAttack : SkillEffect
    {
        [SerializeField] private int _damageFlat = 0;
        [SerializeField] private float _damagePrctg = 0;
        [SerializeField, Range(-1f, 1f)] private float _crPrctg = 0f;
        [SerializeField] private float _crFlat = 0f;
        [SerializeField] private float _cdPrctg = 0f;
        [SerializeField] private float _cdFlat = 0f;

        public override SkillContext Execute(SkillContext context)
        {
            var a = context.AttackData;
            context.AttackData.Damage += (int)(a.Damage * _damagePrctg) + _damageFlat;
            context.AttackData.CritRate += a.CritRate * _crPrctg + _crFlat;
            context.AttackData.CritDamage += a.CritDamage * _cdPrctg + _cdFlat;
            return context;
        }
    }
}