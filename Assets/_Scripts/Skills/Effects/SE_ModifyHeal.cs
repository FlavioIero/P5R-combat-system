using System;
using UnityEngine;


namespace Skills.Effects
{
    [Serializable, Tooltip("Adds or removes from HealData")]
    public class SE_ModifyHeal : SkillEffect
    {
        [SerializeField] private int _healFlat = 0;
        [SerializeField] private float _healPrctg = 0f;

        public override SkillContext Execute(SkillContext context)
        {
            var h = context.HealData;
            context.HealData.HealAmount += (int)(h.HealAmount * _healPrctg) + _healFlat;

            return context;
        }
    }
}