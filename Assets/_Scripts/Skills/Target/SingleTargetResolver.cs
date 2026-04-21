using System;
using System.Collections.Generic;


[Serializable]
public class SingleTargetResolver : TargetResolver
{
    public override List<DamageEntity> GetTargets(TargetingContext context)
    {
        return new List<DamageEntity> { context.SelectedTarget };
    }   
}