using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Puzzle", menuName = "Objects/Puzzle", order = 0 /*primero*/)] // creable desde unity 
public class PuzzleProperties : ScriptableObject
{
    [SerializeField] private PuzzleValues _puzzleValues;

    public string Id =>_puzzleValues.Id; 
    public int Level => _puzzleValues.Level;
    public int TotalSteps => _puzzleValues.TotalSteps;
    public List<string> DoorsToOpen => _puzzleValues.DoorsToOpen;
    
}

[System.Serializable]
public struct PuzzleValues
{
    public string Id;
    public int Level;
    public int TotalSteps;
    public List<string> DoorsToOpen;

}
