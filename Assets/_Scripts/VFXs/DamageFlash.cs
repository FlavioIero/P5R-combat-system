using UnityEngine;
using System.Collections;

public class DamageFlash : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private float _duration = 0.1f;
    [SerializeField] private Color _color;

    private Color _originalColor;
    private Coroutine _flashCoroutine;

    private void Awake()
    {
        if (_renderer == null)
            _renderer = GetComponentInChildren<SpriteRenderer>();

        _originalColor = _renderer.color;
    }

    public void Flash()
    {
        if (_flashCoroutine != null)
            StopCoroutine(_flashCoroutine);

        _flashCoroutine = StartCoroutine(FlashRoutine());
    }

    //private IEnumerator FlashRoutine()
    //{
    //    _materialInstance.color = Color.red;

    //    yield return new WaitForSeconds(flashDuration);

    //    _materialInstance.color = _originalColor;
    //}

    private IEnumerator FlashRoutine()
    {
        _renderer.color = _color;

        float t = 0f;

        while (t < _duration)
        {
            t += Time.deltaTime;
            _renderer.color = Color.Lerp(_color, _originalColor, t / _duration);
            yield return null;
        }

        _renderer.color = _originalColor;
    }
}