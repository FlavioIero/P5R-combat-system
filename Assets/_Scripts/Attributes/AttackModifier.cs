using System;


[Serializable]
public abstract class AttackModifier : IAttackModifier
{
    public abstract void ProcessAttack(ref AttackData attack);
}
