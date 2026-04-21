using System;


namespace Skills
{
    [Serializable]
    public abstract class SkillEffect
    {
        public abstract SkillContext Execute(SkillContext context);
    }
}