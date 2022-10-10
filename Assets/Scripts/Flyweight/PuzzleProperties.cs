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
    public string DoorName => _puzzleValues.DoorName;
    
}

[System.Serializable]
public struct PuzzleValues
{
    public string Id;
    public int Level;
    public int TotalSteps;
    public string DoorName;

}
