using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable, Tooltip("Targets all selected team (allies or enemies)")]
public class AllTeamResolver : TargetResolver
{
    public override List<DamageEntity> GetTargets(TargetingContext context)
    {
        throw new NotImplementedException();
        //return TeamsManager.Instance.GetTeam(context.SelectedTarget);
    }
}