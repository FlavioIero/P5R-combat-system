using System;


[Serializable]
public abstract class IncomingAttackModifier : IIncomingAttackModifier
{
    public abstract SkillContext ProcessIncomingAttack(SkillContext skillContext);
}
