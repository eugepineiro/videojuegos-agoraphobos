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
   

    public bool IsSolved => _isSolved;
    [SerializeField] private bool _isSolved = false;

    public void Solve() => EventsManager.instance.EventPuzzleSolved(_puzzleProperties);
}