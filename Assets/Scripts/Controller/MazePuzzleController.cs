using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePuzzleController : PuzzleController
{
    static public MazePuzzleController mazeInstance;
    
    private void Awake() 
    {
        if( mazeInstance != null) Destroy(this);
        mazeInstance = this; 
    }

   
}