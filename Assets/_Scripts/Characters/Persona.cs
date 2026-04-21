using Skills;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


public class Persona : MonoBehaviour
{
    public const int MAX_NUMBER_OF_SKILLS = 8;

    public string Name = "";

    [SerializeReference, SubclassSelector] public List<ElementInteraction> ElementsInteractions = new();
    [SerializeField] public List<Skill> Skills = new(MAX_NUMBER_OF_SKILLS);
    [SerializeField] public CharacterStats Stats;


    private void Awake()
    {
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

}