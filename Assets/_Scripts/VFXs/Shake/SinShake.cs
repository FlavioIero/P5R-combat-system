using System;
using System.Collections;
using UnityEngine;


[Serializable]
public class SinShake : ShakeMethod
{
    [SerializeField] private float _speed = 20f;
    [SerializeField] private Vector3 _maxOffset = new Vector3(10f, 10f, 0f);
    [SerializeField] private float _durationSec = 0.8f;

    private float _time;

    public override IEnumerator Play(ShakeSettings settings, GameObject gameObject)
    {
        settings.InitialPosition = gameObject.transform.localPosition;
        _time = 0f;
        float elapsed = 0f;

        while (elapsed < _durationSec)
        {
            _time += Time.deltaTime * _speed;

            float randomMultiplierX = UnityEngine.Random.Range(0.5f, 3f);
            float randomMultiplierY = UnityEngine.Random.Range(0.5f, 3f);
            float randomMultiplierZ = UnityEngine.Random.Range(0.5f, 3f);

            float offsetX = Mathf.Sin(_time) * _maxOffset.x * randomMultiplierX;
            float offsetY = Mathf.Cos(_time) * _maxOffset.y * randomMultiplierY;
            float offsetZ = Mathf.Sin(_time) * _maxOffset.z * randomMultiplierZ;

            gameObject.transform.localPosition = settings.InitialPosition + new Vector3(offsetX, offsetY, offsetZ);

            elapsed += Time.deltaTime;
            yield return null;
        }

        gameObject.transform.localPosition = settings.InitialPosition;
        settings.ShakeRoutine = null;
    }
}