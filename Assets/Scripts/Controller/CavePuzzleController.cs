using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavePuzzleController : PuzzleController
{
    static public CavePuzzleController caveInstance;
    
    private void Awake() 
    {
        if( caveInstance != null) Destroy(this);
        caveInstance = this; 
    }

    public void OpenCave()
    {	
        base.Solve();
    }
}