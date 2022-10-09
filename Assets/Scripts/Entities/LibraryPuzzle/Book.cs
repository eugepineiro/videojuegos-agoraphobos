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

    public override void LetGo() { 
        base.LetGo();
       
        var didHit = Physics.Raycast(this.transform.position, -this.transform.up, out var hit, 0.5F);
        Debug.Log(didHit);
        if(didHit && hit.transform.gameObject == _shelf ){
            /* Book hits shelf */ 
            _libraryPuzzleController.SetBook(this.name, _shelf.name);
        }
    }

    public override void Grab() { 
        base.Grab();
        _libraryPuzzleController.RemoveBook(this.name);
    }
    
    /*private bool CorrectPosition(){
        if(transform.position.x > 0 && transform.position.x > 0 && transform.position.y > 0)
        return true;
    }  
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if(other.gameObject == _shelf ){

            _libraryPuzzleController.SetBook(this.name, _shelf.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print(other.gameObject.name);
        if(other.gameObject == _shelf ){

            _libraryPuzzleController.RemoveBook(this.name, _shelf.name);
        }
    } */ 

  
}
