using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : GrabbableObject
{
    private LibraryPuzzleController _libraryPuzzleController; 
 
    [SerializeField] private GameObject _shelf;


    void Start()
    {
        _libraryPuzzleController = GameObject.Find("LibraryPuzzles").GetComponent<LibraryPuzzleController>();
    }

    /* public override void LetGo() { 
        base.LetGo();
        if(CorrectPosition()){
            _libraryPuzzleController.Solve();
        }
    }
    
    private bool CorrectPosition(){
        if(transform.position.x > 0 && transform.position.x > 0 && transform.position.y > 0)
        return true;
    } */ 
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if(other.gameObject == _shelf ){

            _libraryPuzzleController.Solve();
        }
    }

  
}
