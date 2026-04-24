using System;
using System.Collections.Generic;
using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;



public class MainMenuUIManager : MonoBehaviour
{
    public static MainMenuUIManager Instance;

    [Header("Canvas")]
    [SerializeField] private GameObject MainMenuNav;
    [SerializeField] private GameObject CharacterSelection;
    [SerializeField] private GameObject Logo;
    [SerializeField] private GameObject BaseBackground;

    [Header("Other UI references")]
    [SerializeField] private TextMeshProUGUI _charactersSelectedNum;

    private List<GameObject> _canvas = new();

    // EVENTS
    [Space]
    public UnityEvent NotEnoughAlliesSelected;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        _canvas.Add(MainMenuNav);
        _canvas.Add(CharacterSelection);
        _canvas.Add(Logo);
        _canvas.Add(BaseBackground);
    }

    private void OnEnable()
    {
        if (TeamsManager.Instance != null)
            Debug.Log("MainMenuUIManager - Subscribing to OnSelectedAlliesChanged event");
        else
            Debug.LogWarning("MainMenuUIManager - TeamsManager.Instance is null in OnEnable");
        TeamsManager.Instance.OnSelectedAlliesChanged += OnSelectedAlliesChanged;
    }

    private void OnDisable()
    {
        TeamsManager.Instance.OnSelectedAlliesChanged -= OnSelectedAlliesChanged;
    }

    private void Start()
    {
        ShowMainMenuNav();
    }

    private void OnSelectedAlliesChanged(List<Character> selectedAllies)
    {
        Debug.Log("MainMenuUIManager - Selected allies: " + selectedAllies.Count);
        _charactersSelectedNum.text = $"{selectedAllies.Count} / {TeamsManager.MAX_ACTIVE_ALLIES}";
    }

    #region public_methods
    public void ShowMainMenuNav()
    {
        ShowCanva(MainMenuNav);
    }

    public void ShowCharacterSelection()
    {
        ShowCanva(CharacterSelection);
    }

    public void ShowLogo()
    {
        ShowCanva(Logo);
    }

    public void ShowBaseBackground()
    {
        ShowCanva(BaseBackground);
    }

    public void Play()
    {
        if (TeamsManager.Instance.GetSelectedAllies().Count < TeamsManager.MAX_ACTIVE_ALLIES)
        {
            NotEnoughAlliesSelected?.Invoke();
            return;
        }
        SceneManager.LoadScene("Game");
    }
    #endregion

    private void ShowCanva(GameObject canva)
    {
        foreach (var c in _canvas)
        {
            c.SetActive(false);
        }
        canva.SetActive(true);
    }

}