using System.Collections.Generic;
using UnityEngine;


public class AllySelectionManager : MonoBehaviour
{
    public static AllySelectionManager Instance;

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

    private void Start()
    {
        List<Character> allies = TeamsManager.Instance.GetUnlockedAllies();
        foreach (var ally in allies)
        {
            CreateCharacterSheet(ally);
        }
    }

    private void CreateCharacterSheet(Character ally)
    {
        GameObject sheet = Instantiate(_characterSheetPrefab, _scrollbarContent.transform);
        sheet.GetComponent<AllySheet>().Initialize(ally);
        sheet.name = $"CharacterSheet";
    }

}