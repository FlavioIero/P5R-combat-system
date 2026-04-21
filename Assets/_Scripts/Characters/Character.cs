using Skills;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


public class Character : DamageEntity
{
    // PUBLIC VARIABLES
    public string Name = "";
    public string Arcana = "";
    public Resources Resources;

    [Space, Header("Debug")]
    [Tooltip("Color of the character when it's their turn")]
    public Color TurnColor;
    [Tooltip("Enemy to attack")]
    public DamageableReference Enemy;

    [HideInInspector] public int Id = ++_id;

    // PROPERTIES
    private bool _thisTurn = false;
    public bool ThisTurn
    {
        get => _thisTurn;
        set
        {
            if (_thisTurn == value)
                return;
            _thisTurn = value;
            if (_thisTurn)
            {
                OnTurnStarted?.Invoke(this);
                ChangeColor(TurnColor);
            }
            else
            {
                OnTurnEnded?.Invoke(this);
                ChangeColor(_originalColor);
            }
        }
    }
    private bool _active = false;
    public bool Active
    {
        get => _active;
        set
        {
            if (_active == value)
                return;
            _active = value;
            if (_active)
                OnActivated?.Invoke(this);
            else
                OnDeactivated?.Invoke(this);
        }
    }
    private bool _dead = false;
    public bool Dead
    {
        get => _dead;
        set
        {
            if (_dead == value)
                return;
            _dead = value;
            if (_dead)
                OnDead?.Invoke(this);
            else
                OnAlive?.Invoke(this);
        }
    }

    // PRIVATE VARIABLES
    private static int _id = -1;
    // REFERENCES
    private Color _originalColor;
    private Persona _persona;
    private Health _health;

    // EVENTS
    public static event Action<Character> OnStart;
    public static event Action<Character> OnActivated;
    public static event Action<Character> OnDeactivated;
    public static event Action<Character> OnTurnStarted;
    public static event Action<Character> OnTurnEnded;
    public static event Action<Character> OnDead;
    public static event Action<Character> OnAlive;
    public static event Action<Character, SkillData> OnSkillUsed;


    private void Awake()
    {
    }

    private void OnEnable()
    {
        _health = gameObject.GetComponent<Health>();
        _health.OnHPChanged += OnHpChanged;
        _health.OnDeath += OnDeath;
        _persona = gameObject.GetComponent<Persona>();

        Resources.HP = (int)_health.HP;
    }

    private void OnDisable()
    {
    }

    private void Start()
    {
        try
        {
            _originalColor = gameObject.GetComponent<SpriteRenderer>().color;
        }
        catch { }

        OnStart?.Invoke(this);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //string s = $"{Name} Enemy == null {Enemy == null}, Enemy.Value == null {Enemy.Value == null}";
            //Debug.Log(s);

            if (!_thisTurn)
                return;

            if (Enemy != null && Enemy.Value != null)
            {
                _persona.Skills[0].Use(this, Enemy.Value);

                string s = $"{Name} attacked {Enemy.Value.name} with {_persona.Skills[0].Data.Name}";
                Debug.Log(s);

                ThisTurn = false;
                Debug.Log($"{Name} this turn {ThisTurn}");
            }
        }
    }

    public override void TakeDamage(SkillContext context)
    {
        // TODO: use passive skills that affect received damage
        // TODO: stats should also affect this

        // can modify the skill context
        bool interactionExists = false;
        foreach (var interaction in _persona.ElementsInteractions)
        {
            if (interaction.Element.Name == context.AttackData.Element.Name)
            {
                interactionExists = true;
                context = interaction.ProcessIncomingAttack(context);
            }
        }

        // Temp 
        if (context.Target == this)
        {
            int dmg = context.AttackData.Damage;
            if (UnityEngine.Random.value < context.AttackData.CritRate)
                dmg = (int)(dmg * context.AttackData.CritDamage);
            _health.HP -= dmg;
        }

        if (gameObject.GetComponent<DamageFlash>() != null)
            gameObject.GetComponent<DamageFlash>()?.Flash();
    }

    public override void Heal(HealData heal)
    {
        // TODO: use passive skills that affect received health
        // TODO: stats should also affect this

        _health.HP += heal.HealAmount;
    }

    private void OnHpChanged(float hp, float maxHp)
    {
        Debug.Log($"{Name} HP: {hp}, Max HP: {maxHp}");
        Resources.HP = (int)_health.HP;
    }

    private void OnDeath()
    {
        Debug.Log($"{Name} died");
    }

    public void ChangeColor(Color color)
    {
        try
        {
            gameObject.GetComponent<SpriteRenderer>().color = color;
        }
        catch { }
    }
}