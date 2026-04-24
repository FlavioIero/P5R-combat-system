using System;
using System.Collections;
using UnityEngine;


[Serializable]
public abstract class ShakeMethod
{
    public abstract IEnumerator Play(ShakeSettings settings, GameObject gameObject);
} 