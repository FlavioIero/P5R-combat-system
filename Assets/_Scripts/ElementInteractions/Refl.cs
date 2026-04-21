using System;


[Serializable]
public class Refl : ElementInteraction
{
    public override SkillContext ProcessIncomingAttack(SkillContext context)
    {
        if (context.AttackData.CanReflect())
        {
            (context.Target, context.Source) = (context.Source, context.Target);
            context.AttackData.Reflected = true;
            context.AttackData.Reflections++;
            context.Target.TakeDamage(context);
        }
        else
        {
            var bloc = new Bloc();
            bloc.ProcessIncomingAttack(context);
        }

        return context;
    }
}
