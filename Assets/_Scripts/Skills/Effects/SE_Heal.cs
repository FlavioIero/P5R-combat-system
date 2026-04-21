using System;


namespace Skills.Effects
{
    [Serializable]
    public class SE_Heal : SkillEffect
    {
        public override SkillContext Execute(SkillContext context)
        {
            context.Target.Heal(context.HealData);

            return context;
        }
    }
}