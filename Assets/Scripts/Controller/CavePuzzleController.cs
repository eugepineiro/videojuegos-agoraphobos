using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallPuzzleController : PuzzleController
{
    static public HallPuzzleController hallInstance;
    
    private void Awake() 
    {
        if( hallInstance != null) Destroy(this);
        hallInstance = this; 
    }

    public void OpenMansionDoor()
    {	
        base.Solve();
    }
}