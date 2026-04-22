using System;
using UnityEngine;


public class CharacterSelectionManager : MonoBehaviour
{
    public static CharacterSelectionManager Instance;

    [SerializeField] private GameObject _characterSheetPrefab;


    [Space, Header("UI References")]
    [SerializeField] private GameObject _scrollbarContent;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        CharacterSheet.OnCharacterSelected += OnCharacterSelected;
    }

    private void OnDisable()
    {
        CharacterSheet.OnCharacterSelected -= OnCharacterSelected;
    }

    private void Start()
    {
        CreateCharacterSheets(10);
    }

    private void CreateCharacterSheets(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject sheet = Instantiate(_characterSheetPrefab, _scrollbarContent.transform);
            sheet.name = $"CharacterSheet_{i + 1}";
        }
    }

    private void OnCharacterSelected(int characterID)
    {
        // notify teams manager
    }


}