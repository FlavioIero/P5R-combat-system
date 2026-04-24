using System;
using UnityEngine;
using System.Collections.Generic;


public class TeamsManager : MonoBehaviour
{
    [Serializable]
    private class AllyState_Serialized
    {
        public Character Ally;
        public AllyState State = new();
    }

    [Serializable]
    private class AllyState
    {
        public bool Unlocked = true;
        [HideInInspector] public bool Selected = false;
        [HideInInspector] public bool ActiveTurn = false;
    }


    public static TeamsManager Instance;

    public const int MAX_ACTIVE_ALLIES = 4;

    // used only to create a dictionary, do not reference this otherwise
    [SerializeField] private List<AllyState_Serialized> _alliesStatesInspector = new();
    [SerializeField] private List<Character> _enemies = new();

    [Header("Debug")]
    public int _turnIdx = 0;

    private List<Character> _activeAllies = new();
    private List<Character> _activeEnemies = new();
    private Dictionary<Character, AllyState> _alliesStates = new();

    // EVENTS
    public event Action<List<Character>> OnSelectedAlliesChanged;
    public event Action<List<Character>> OnActiveAlliesChanged;
    public event Action<List<Character>> OnActiveEnemiesChanged;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (var state in _alliesStatesInspector)
        {
            _alliesStates[state.Ally] = state.State;
        }
    }

    private void OnEnable()
    {
        Character.OnTurnEnded += Ally_OnTurnEnded;
        AllySheet.OnAllySelected += OnAllySelected;
        AllySheet.OnAllyDeselected += OnAllyDeselected;
    }

    private void OnDisable()
    {
        Character.OnTurnEnded -= Ally_OnTurnEnded;
        AllySheet.OnAllySelected -= OnAllySelected;
        AllySheet.OnAllyDeselected += OnAllyDeselected;
    }

    private void OnAllySelected(Character ally)
    {
        if (ally.Team != Team.Good)
            return;

        _activeAllies.Add(ally);
        if (_activeAllies.Count < MAX_ACTIVE_ALLIES)
            _activeAllies.Add(ally);

        _alliesStates[ally].Selected = true;

        Debug.Log("Selected allies: " + GetSelectedAllies().Count);
        OnSelectedAlliesChanged?.Invoke(GetSelectedAllies());
        Debug.Log("Selected allies: " + GetSelectedAllies().Count);

        // temp
        _activeAllies[_turnIdx].ThisTurn = true;
    }

    private void OnAllyDeselected(Character ally)
    {
        if (ally.Team != Team.Good)
            return;

        _activeAllies.Remove(ally);
        _alliesStates[ally].Selected = false;

        Debug.Log("Selected allies: " + GetSelectedAllies().Count);
        OnSelectedAlliesChanged?.Invoke(GetSelectedAllies());
        Debug.Log("Selected allies: " + GetSelectedAllies().Count);
    }

    #region getters
    public List<Character> GetUnlockedAllies()
    {
        List<Character> allies = new();
        foreach (var state in _alliesStates)
        {
            if (state.Value.Unlocked)
                allies.Add(state.Key);
        }

        return allies;
    }

    public List<Character> GetSelectedAllies()
    {
        List<Character> allies = new();
        foreach (var state in _alliesStates)
        {
            if (state.Value.Selected)
                allies.Add(state.Key);
        }
        return allies;
    }
    #endregion

    private void Ally_OnTurnEnded(Character character)
    {
        StartCoroutine(NextTurn());
    }

    private System.Collections.IEnumerator NextTurn()
    {
        yield return null; 

        if (_activeAllies.Count == 0)
            yield break;

        foreach (var a in _activeAllies)
            a.ThisTurn = false;

        _turnIdx = (_turnIdx + 1) % _activeAllies.Count;

        _activeAllies[_turnIdx].ThisTurn = true;
    }
}