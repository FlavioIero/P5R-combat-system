using System;
using System.Collections;
using UnityEngine;


[Serializable]
public class StraightShake : ShakeMethod
{
    [SerializeField] private float _speed = 20f;
    [SerializeField] private Vector3 _offset = new Vector3(10f, 0f, 0f);
    [SerializeField] private float _durationSec = 0.6f;

    private float _time;


    public override IEnumerator Play(ShakeSettings settings, GameObject gameObject)
    {
        settings.InitialPosition = gameObject.transform.localPosition;
        float elapsed = 0f;

        while (elapsed < _durationSec)
        {
            elapsed += Time.deltaTime;

            float t = Mathf.PingPong(elapsed * _speed, 1f) * 2f - 1f;
            Vector3 offset = new Vector3(
                t * _offset.x,
                t * _offset.y,
                t * _offset.z
            );
            gameObject.transform.localPosition = settings.InitialPosition + offset;

            yield return null;
        }

        gameObject.transform.localPosition = settings.InitialPosition;
        settings.ShakeRoutine = null;
    }
}