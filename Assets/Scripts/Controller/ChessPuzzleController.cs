using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    

public class ChessPuzzleController : MonoBehaviour, IPuzzle
{
    public bool IsSolved => _isSolved;
    [SerializeField] private bool _isSolved = false;
    public GameObject PuzzleObject => this.gameObject;

    private void Awake()
    {
        GetComponent<Chess>().RandomizePositions();
    }
    
    public bool CheckSolved() => GetComponent<Chess>().ChessTableOnInitialDisposition();
    
    public void Solve() => _isSolved = CheckSolved();
}
