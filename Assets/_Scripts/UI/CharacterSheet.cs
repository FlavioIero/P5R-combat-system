using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;


public class CharacterSheet : MonoBehaviour
{
    private class Aspect
    {
        public Color NameColor;
        public Color ArcanaColor;
        public Color BackgroundColor;
        public Texture BackgroundImage;
    }

    // PUBLIC VARIABLES
    [HideInInspector] public int CharacterID;

    [SerializeField] private Aspect _selectedAspect;

    // REFERENCES
    [SerializeField] private TextMeshPro _name;
    [SerializeField] private TextMeshPro _arcana;
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Button _button;
    [SerializeField] private Image _characterImage;

    // PRIVATE VARIABLES
    private bool _selected = false;
    private Aspect _originalAspect = new();

    // EVENTS
    public static event Action<int> OnCharacterSelected;

    private void Awake()
    {
        _button.clicked += OnButtonClicked;

        _originalAspect.NameColor = _name.color;
        _originalAspect.ArcanaColor = _arcana.color;
        _originalAspect.BackgroundColor = _backgroundImage.tintColor;
        _originalAspect.BackgroundImage = _backgroundImage.image;
    }

    public void Initialize(int characterID)
    {
        CharacterID = characterID;
    }

    private void OnButtonClicked()
    {
        OnCharacterSelected?.Invoke(CharacterID);
        _selected = !_selected;
        if (_selected )
            ChangeAspect(_selectedAspect);
        else 
            ChangeAspect(_originalAspect);
    }

    private void ChangeAspect(Aspect aspect)
    {
        _name.color = aspect.NameColor;
        _arcana.color = aspect.ArcanaColor;
        _backgroundImage.tintColor = aspect.BackgroundColor;
        _backgroundImage.image = aspect.BackgroundImage ?? _backgroundImage.image;
    }

}
