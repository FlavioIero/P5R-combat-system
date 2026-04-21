using System;
using System.Collections.Generic;
using UnityEngine;


namespace Skills
{
    [CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/Skill")]
    public class SkillData : ScriptableObject
    {
        public string Name;
        [TextArea(2, 5)] public string Description;
        public Resources Resources;
        [SerializeReference, SubclassSelector] public TargetResolver TargetResolver;
        [SerializeReference, SubclassSelector] public List<SkillEffect> Effects;

        // TODO: Add GUI stuff and maybe animations or smth


        

        /*
        public Skill Clone()
        {
            var clone = Instantiate(this);

            // Clona TargetResolver (se serve stato runtime)
            if (TargetResolver is ICloneable cloneableResolver)
                clone.TargetResolver = (ITargetResolver)cloneableResolver.Clone();

            // Clona Effects
            var newEffects = new List<SkillEffect>();
            foreach (var effect in Effects)
            {
                if (effect is ICloneable cloneableEffect)
                    newEffects.Add((SkillEffect)cloneableEffect.Clone());
                else
                    newEffects.Add(effect); // fallback (attenzione!)
            }
            clone.Effects = newEffects;

            return clone;
        }
        */
    }
}