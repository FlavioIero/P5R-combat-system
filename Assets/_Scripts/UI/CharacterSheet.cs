using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CharacterSheet : MonoBehaviour
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
    [HideInInspector] public int CharacterID;

    [SerializeField] private Aspect _selectedAspect;

    // REFERENCES
    [Header("References")]
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _arcana;
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
        _originalAspect.NameColor = _name.color;
        _originalAspect.ArcanaColor = _arcana.color;
        _originalAspect.BackgroundColor = _backgroundImage.color;
        _originalAspect.BackgroundImage = _backgroundImage.sprite;
    }

    public void Initialize(int characterID)
    {
        CharacterID = characterID;
    }

    public void OnButtonClicked()
    {
        Debug.Log("ButtonClicked");
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
        _backgroundImage.color = aspect.BackgroundColor;
        _backgroundImage.sprite = aspect.BackgroundImage ?? _backgroundImage.sprite;
    }

}
