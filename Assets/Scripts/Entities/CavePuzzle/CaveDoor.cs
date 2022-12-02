using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveDoor : MonoBehaviour
{
    private CavePuzzleController _cavePuzzleController;

    void Start()
    {
        _cavePuzzleController = GameObject.Find("CavePuzzles").GetComponent<CavePuzzleController>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.name == "Pickaxe" /*other.CompareTag("Player")*/ )
        {
			Debug.Log("Pickaxe hit cave door");
            
            EventsManager.instance.EventDoorOpened(); //Opened door sound
            _cavePuzzleController.OpenCaveDoor(); //Solves puzzle
        }
    }
    
}
