using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable, Tooltip("Targets the selected fighter and the 2 allies on his sides")]
public class SideTargetsResolver : TargetResolver
{
    public override List<DamageEntity> GetTargets(TargetingContext context)
    {
        throw new NotImplementedException();

        //List<DamageEntity> targets = new(){ context.SelectedTarget };
        //if (TeamsManager.Instance.Left(context.SelectedTarget, out DamageEntity l))
        //    targets.Add(l);
        //if (TeamsManager.Instance.Right(context.SelectedTarget, out DamageEntity r))
        //    targets.Add(r);

    }
}