using System;
using UnityEngine;


[Serializable]
public class AttackData
{
    private const int MAX_REFLECTIONS = 1;

    [Min(0f)] public int Damage = 5;
    [Range(0f, 1f)] public float CritRate = 0;
    [Min(0f)] public float CritDamage = 0;
    [SerializeReference, SubclassSelector] public Element Element;

    // idk if i will need these
    [HideInInspector] public int Reflections = 0;
    [HideInInspector] public bool Reflected = false;
    [HideInInspector] public bool Blocked = false;
    [HideInInspector] public bool Absorbed = false;


    public AttackData Clone()
    {
        var atkData = new AttackData();
        atkData.Damage = Damage;
        atkData.CritRate = CritRate;
        atkData.CritDamage = CritDamage;
        atkData.Element = Element;
        atkData.Reflections = Reflections;
        atkData.Reflected = Reflected;
        atkData.Blocked = Blocked;
        atkData.Absorbed = Absorbed;

        return atkData;
    }

    public bool CanReflect()
    {
        return Reflections < MAX_REFLECTIONS;
    }
}
