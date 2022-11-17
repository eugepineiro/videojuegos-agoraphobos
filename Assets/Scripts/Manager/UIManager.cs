using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    
    /* Image Referece */
    [SerializeField] private Image _lifebar;
    
    /* Text Reference */
    [SerializeField] private TextMeshProUGUI _steps;
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private TextMeshProUGUI _time;

    private float timeRemaining; 

    private void Start()
    {
		timeRemaining = GameManager.instance.GetMaxTime();
        _level.text = $"Level 1 of {GameManager.instance.GetTotalPuzzles()}";
        
        /* Subscribe to events */ 
        EventsManager.instance.OnPuzzleSolved += OnPuzzleSolved;
        EventsManager.instance.OnStepSolved += OnStepSolved;
        EventsManager.instance.OnCharacterLifeChange += OnCharacterLifeChange;
    }

    private void OnStepSolved(int stepsSolved, int totalSteps)
    {
        _steps.text = $"{stepsSolved} of {totalSteps}";
    } 
    
    private void OnPuzzleSolved(PuzzleProperties puzzleProperties)
    {
        _level.text = $"Level {puzzleProperties.Level+1} of {GameManager.instance.GetTotalPuzzles()}";
        _steps.text = "0";
    }
    
    private void OnCharacterLifeChange(float currentLife, float maxLife)
    {
        _lifebar.fillAmount = currentLife / maxLife;
    }
    private void Update()
    {
        if (timeRemaining > 0)
        {
            float minutes = Mathf.Floor(timeRemaining / 60);
            float seconds = timeRemaining%60;
            _time.text = $"Time Left {minutes}:{Mathf.RoundToInt(seconds)}";
            timeRemaining -= Time.deltaTime;
        }
        
    }

}