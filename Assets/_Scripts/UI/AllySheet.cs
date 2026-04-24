using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class AllySheet : MonoBehaviour
{
    [Serializable]
    private class Aspect
    {
        public Color NameColor;
        public Color ArcanaColor;
        public Color BackgroundColor;
        public Sprite BackgroundImage;
    }

    // PUBLIC VARIABLES
    [HideInInspector] public Character Ally;

    [SerializeField] private Aspect _selectedAspect;

    // REFERENCES
    [Header("References")]
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _arcana;
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Button _button;
    [SerializeField] private Image _characterImage;

    private bool _selected = false;
    public bool Selected
    {
        get => _selected;
        set
        {
            if (_selected == value)
                return;
            _selected = value;
            if (_selected)
            {
                ChangeAspect(_selectedAspect);
                OnAllySelected?.Invoke(Ally);
            }
            else
            {
                ChangeAspect(_originalAspect);
                OnAllyDeselected?.Invoke(Ally);
            }
        }
    }
    private Aspect _originalAspect = new();

    // EVENTS
    public static event Action<Character> OnAllySelected;
    public static event Action<Character> OnAllyDeselected;


    private void Awake()
    {
        _originalAspect.NameColor = _name.color;
        _originalAspect.ArcanaColor = _arcana.color;
        _originalAspect.BackgroundColor = _backgroundImage.color;
        _originalAspect.BackgroundImage = _backgroundImage.sprite;
    }

    public void Initialize(Character ally)
    {
        Ally = ally;
        _name.text = Ally.Name;
        _arcana.text = Ally.Arcana;
        // image!!!!
    }

    public void OnButtonClicked()
    {
        Selected = !Selected;
    }

    private void ChangeAspect(Aspect aspect)
    {
        _name.color = aspect.NameColor;
        _arcana.color = aspect.ArcanaColor;
        _backgroundImage.color = aspect.BackgroundColor;
        _backgroundImage.sprite = aspect.BackgroundImage ?? _backgroundImage.sprite;
    }

}
