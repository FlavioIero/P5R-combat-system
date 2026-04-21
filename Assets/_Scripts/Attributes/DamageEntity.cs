using UnityEngine;


public enum Team
{
    Good = 0,
    Evil = 1,
}


public abstract class DamageEntity : MonoBehaviour
{
    public Team Team;

    public abstract void TakeDamage(SkillContext context);
    public abstract void Heal(HealData heal);
}