using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    

public class ChessPuzzleController : PuzzleController
{
    //public bool IsSolved => _isSolved;
    //[SerializeField] private bool _isSolved = false;
    //public GameObject PuzzleObject => this.gameObject;
     

    private void Awake()
    {
        GetComponent<Chess>().RandomizePositions();
    }
    
    public bool CheckSolved() => GetComponent<Chess>().ChessTableOnInitialDisposition();
    
    // chess picec le avisa al controller su posicion nueva
    public void DispositionChanged(){
        if(CheckSolved())
            Solve();
    }

    //public void Solve() => _isSolved = CheckSolved();
}
