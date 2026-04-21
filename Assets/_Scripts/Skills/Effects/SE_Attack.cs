using System;


namespace Skills.Effects
{
    [Serializable]
    public class SE_Attack : SkillEffect
    {
        public override SkillContext Execute(SkillContext context)
        {
            context.Target.TakeDamage(context);

            return context;
        }
    }
}