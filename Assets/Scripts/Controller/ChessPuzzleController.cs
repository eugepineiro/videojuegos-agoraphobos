using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    

public class ChessPuzzleController : PuzzleController
{
    //public bool IsSolved => _isSolved;
    //[SerializeField] private bool _isSolved = false;
    //public GameObject PuzzleObject => this.gameObject;
    private Chess _chess;

    private void Awake()
    {
        _chess = GetComponent<Chess>();
        _chess.RandomizePositions();
    }
    

    public void ChessPieceMoved(Vector3 localPosition, string piece)
    {
        
    }
    
    public bool CheckSolved() => GetComponent<Chess>().ChessTableOnInitialDisposition();
    
    // chess picec le avisa al controller su posicion nueva
    public void DispositionChanged(){
        if(CheckSolved())
            Solve();
    }

    //public void Solve() => _isSolved = CheckSolved();
}
