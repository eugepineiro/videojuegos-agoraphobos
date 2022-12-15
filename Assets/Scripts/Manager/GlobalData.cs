using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    // Data que no se destruye al cambiar de scene
    static public GlobalData instance; 

    public bool IsVictory => _isVictory;
    [SerializeField] private bool _isVictory;
    
    public string Chapter => _chapter;
    [SerializeField] private string _chapter;
    
    public string MaxChapter => _maxChapter;
    [SerializeField] private string _maxChapter;
    
    public int MaxMinutes => _maxMinutes;
    [SerializeField] private int _maxMinutes = 30;
    
    public int PuzzlesSolved => _puzzlesSolved;
    [SerializeField] private int _puzzlesSolved;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject); 
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(this);
    }

    public void SetVictoryField(bool isVictory) => _isVictory = isVictory;
    
    public void SetChapter(string chapter) => _chapter = chapter;
    public void SetMaxChapter(string chapter) => _maxChapter = chapter;

    public string GetMaxChapter()
    {
        return _maxChapter;
    }

    public void SetPuzzlesSolved(int puzzlesSolved) => _puzzlesSolved = puzzlesSolved;
    
    public int GetMaxMinutes()
    {
        return _maxMinutes;
    }
}
