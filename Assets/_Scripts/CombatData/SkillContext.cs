using UnityEngine;
using System;


[Serializable]
public class SkillContext
{
    public AttackData AttackData = new();
    public HealData HealData = new();
    [HideInInspector] public DamageEntity Source;
    [HideInInspector] public DamageEntity Target;
}