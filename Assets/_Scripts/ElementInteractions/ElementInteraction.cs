using System;
using UnityEngine;


[Serializable]
public abstract class ElementInteraction : IElementInteraction, IIncomingAttackModifier
{
    // REMOVE ELEMENT REFERENCE AND USE IT EXTERNALLY 
    // i.e. in a dictionary inside the damageable
    [SerializeReference, SubclassSelector] public Element Element;

    public abstract SkillContext ProcessIncomingAttack(SkillContext context);
}
