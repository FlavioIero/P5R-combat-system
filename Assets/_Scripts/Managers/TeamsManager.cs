using System;
using UnityEngine;
using System.Collections.Generic;


public class TeamsManager : MonoBehaviour
{
    public static TeamsManager Instance;

    // this is garbage and it's temporary, just to test stuff
    public const int MAX_ACTIVE_ALLIES = 4;
    public List<Character> Allies = new();
    public List<Character> ActiveAllies = new();
    public List<DamageEntity> Enemies = new();
    
    public int _turnIdx = 0;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        Character.OnStart += Ally_OnEnabled;
        Character.OnTurnEnded += Ally_OnTurnEnded;
 
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {

    }

    private void Start()
    {
        
    }

    private void Ally_OnEnabled(Character character)
    {
        if (character.Team != Team.Good)
            return;

        Allies.Add(character);
        if (ActiveAllies.Count < MAX_ACTIVE_ALLIES)
            ActiveAllies.Add(character);

        ActiveAllies[_turnIdx].ThisTurn = true;
    }

    private void Ally_OnTurnEnded(Character character)
    {
        StartCoroutine(NextTurn());
    }

    private System.Collections.IEnumerator NextTurn()
    {
        yield return null; 

        if (ActiveAllies.Count == 0)
            yield break;

        foreach (var a in ActiveAllies)
            a.ThisTurn = false;

        _turnIdx = (_turnIdx + 1) % ActiveAllies.Count;

        ActiveAllies[_turnIdx].ThisTurn = true;
    }
}