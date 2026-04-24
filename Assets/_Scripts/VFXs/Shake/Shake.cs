using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;


[Serializable]
public class ShakeSettings
{
    [Header("Shake Settings")]
    [HideInInspector] public Vector3 InitialPosition;
    [HideInInspector] public Coroutine ShakeRoutine;
}

public class Shake : MonoBehaviour
{
    [SerializeReference, SubclassSelector] private ShakeMethod _shakeMethod;
    private ShakeSettings _settings = new();


    private void Awake()
    {
        _settings.InitialPosition = transform.localPosition;
    } 

    public void StartShake()
    {
        if (_settings.ShakeRoutine != null)
        {
            StopCoroutine(_settings.ShakeRoutine);
            transform.localPosition = _settings.InitialPosition;
        }

        _settings.ShakeRoutine = StartCoroutine(_shakeMethod.Play(_settings, gameObject));
    }
}