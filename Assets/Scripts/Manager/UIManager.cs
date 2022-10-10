using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    /* Text Reference */
    [SerializeField] private TextMeshProUGUI _steps;
    [SerializeField] private TextMeshProUGUI _level;
    
    [SerializeField] private TextMeshProUGUI _time;
    
    [SerializeField] pivate float timeRemaining = 10;

    private void Start()
    {
        EventsManager.instance.OnPuzzleSolved += OnPuzzleSolved; //subscribe to event
        EventsManager.instance.OnStepSolved += OnStepSolved; 
    }

    private void OnStepSolved(int stepsSolved, int totalSteps)
    {
        _steps.text = $"{stepsSolved} of {totalSteps}";
    } 
    
    private void OnPuzzleSolved(PuzzleProperties puzzleProperties)
    {
        _level.text = $"Level {puzzleProperties.Level+1} of 3";
    }

    private void Update()
    {
        if (timeRemaining > 0) timeRemaining -= Time.deltaTime;
        _time.text = $"Time Left {timeRemaining}";
    }

}