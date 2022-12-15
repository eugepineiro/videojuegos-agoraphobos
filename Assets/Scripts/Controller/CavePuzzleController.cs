using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavePuzzleController : PuzzleController
{
    static public CavePuzzleController caveInstance;
    [SerializeField] private GameObject _caveDoor;
    
    private void Awake() 
    {
        if (caveInstance != null)
        {
            Destroy(this);
            return;
        }
            
        caveInstance = this; 
    }

    public void OpenCaveDoor()
    {
        _caveDoor.SetActive(false);
        SolveStep(true);
        base.Solve();
    }
}