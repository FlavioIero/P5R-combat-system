using System;


[Serializable]
public class Bloc : ElementInteraction
{
    public override SkillContext ProcessIncomingAttack(SkillContext context)
    {
        context.AttackData.Damage = 0;
        // probably useless
        context.AttackData.Blocked = true;

        return context;
    }
}
