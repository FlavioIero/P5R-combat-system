using System;
using UnityEngine;


// This class is needed to centralize the cast from MonoBehavior to IDamageable
// this cast will likely not be needed after making TurnManager, GameManager etc.
// The only purpose of this class is to debug faster
[Serializable]
public class DamageableReference
{
    [SerializeField] private Character _target;

    public DamageEntity Value => _target as DamageEntity;
}