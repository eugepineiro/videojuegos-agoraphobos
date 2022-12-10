using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavePuzzleController : PuzzleController
{
    static public CavePuzzleController caveInstance;
    [SerializeField] private GameObject _caveDoor;
    
    private void Awake() 
    {
        if( caveInstance != null) Destroy(this);
        caveInstance = this; 
    }

    public void OpenCaveDoor()
    {
        Debug.Log("Solved cave puzzle");
        _caveDoor.SetActive(false);
        base.Solve();
    }
}