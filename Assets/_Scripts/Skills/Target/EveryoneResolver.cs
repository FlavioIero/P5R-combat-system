using System.Collections.Generic;
using System;


[Serializable]
public class EveryoneResolver : TargetResolver
{
    public override List<DamageEntity> GetTargets(TargetingContext context)
    {
        throw new NotImplementedException();

        //var t1 = TeamsManager.Instance.GetAlliesAsDamageEntities();
        //var t2 = TeamsManager.Instance.GetEnemiesAsDamageEntities();
        //return t1.AddRange(t2);
    }
}