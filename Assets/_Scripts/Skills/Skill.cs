using System;
using UnityEngine;
using Unity;


namespace Skills
{
    [Serializable]
    public class Skill
    {
        public SkillData Data;


        public Skill()
        {
            Data = UnityEngine.Object.Instantiate(Data);
        }

        public void Use(DamageEntity source, DamageEntity selectedTarget)
        {
            var targetingContext = new TargetingContext
            {
                Source = source,
                SelectedTarget = selectedTarget
            };

            Debug.Log($"source name: {source.name}; target name: {selectedTarget.name}");
            var targets = Data.TargetResolver.GetTargets(targetingContext);

            foreach (var target in targets)
            {
                var context = new SkillContext
                {
                    Source = source,
                    Target = target,
                    AttackData = new AttackData(),
                    HealData = new HealData()
                };

                foreach (var effect in Data.Effects)
                {
                    context = effect.Execute(context);
                }
            }
        }
    }
}