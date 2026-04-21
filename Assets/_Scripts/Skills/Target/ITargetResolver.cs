using System.Collections.Generic;


public interface ITargetResolver
{
    List<DamageEntity> GetTargets(TargetingContext context);
}