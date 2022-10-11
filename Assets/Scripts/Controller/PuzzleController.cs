using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour, IPuzzle
{
    [SerializeField] private PuzzleProperties _puzzleProperties;
    public string Id => _puzzleProperties.Id; 
    public int Level => _puzzleProperties.Level;
    public int TotalSteps => _puzzleProperties.TotalSteps;
    public List<string> DoorsToOpen => _puzzleProperties.DoorsToOpen;
    
    public int StepsSolved => _stepsSolved;
    [SerializeField] private int _stepsSolved = -1;
    
    public bool IsSolved => _isSolved;
    [SerializeField] private bool _isSolved = false;

    public void Solve() => EventsManager.instance.EventPuzzleSolved(_puzzleProperties);

    public void SolveStep(bool isCorrect)
    {
        if (isCorrect)
        {
            _stepsSolved++;
        }
        else
        {
            _stepsSolved--;
        }
        EventsManager.instance.EventStepSolved(StepsSolved,TotalSteps); // Update UI 
    }
    public void SolveStep(int steps)
    {
        _stepsSolved = steps;
        EventsManager.instance.EventStepSolved(StepsSolved,TotalSteps); // Update UI 
    }
    
    void Start()
    {
        SolveStep(true); // Set 0 of total_steps in UI
    }
}