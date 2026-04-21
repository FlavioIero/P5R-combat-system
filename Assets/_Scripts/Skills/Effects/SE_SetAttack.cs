using System;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace Skills.Effects
{
    [Serializable, Tooltip("Sets the default values for AttackData")]
    public class SE_SetAttack : SkillEffect
    {
        [SerializeField] private AttackData _attackData;

        public override SkillContext Execute(SkillContext context)
        {
            context.AttackData = _attackData.Clone();

            return context;
        }
    }
}