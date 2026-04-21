using System;
using System.Collections.Generic;


[Serializable]
public abstract class TargetResolver : ITargetResolver
{
    public abstract List<DamageEntity> GetTargets(TargetingContext context);
}