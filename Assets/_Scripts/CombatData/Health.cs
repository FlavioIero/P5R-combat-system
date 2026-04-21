using System;
using UnityEngine;


[Serializable]
public class Health : MonoBehaviour
{
    [SerializeField] private int _hp = 100; // TODO: make it private and readonly in inspector with custom attribute
    public int HP
    {
        get => _hp;
        set
        {
            if (_hp == value)
                return;

            _hp = (int)Mathf.Clamp(value, 0, _maxHP);
            if (_hp <= 0)
                Die();

            OnHPChanged?.Invoke(_hp, MaxHP);
        }
    }

    [SerializeField] private int _maxHP = 100;
    public int MaxHP
    {
        get => _maxHP;
        set
        {
            if (_maxHP == value)
                return;

            _maxHP = (int)Mathf.Max(0.001f, value);
            // for now I will do this, in the future
            // the behavior could be injected
            if (_maxHP < _hp)
                HP = _maxHP;
            else if (_maxHP > _hp)
                HP += value;

            OnHPChanged?.Invoke(_hp, MaxHP);
        }
    }


    public event Action<float, float> OnHPChanged; // hp, max hp
    public event Action OnDeath;


    private void Start()
    {
        _hp = _maxHP;
        OnHPChanged?.Invoke(_hp, _maxHP);
    }

    private void Die()
    {
        OnDeath?.Invoke();
    }
}