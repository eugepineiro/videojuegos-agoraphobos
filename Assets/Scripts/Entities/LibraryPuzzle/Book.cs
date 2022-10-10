using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : GrabbableObject
{
    private LibraryPuzzleController _libraryPuzzleController; 
 
    [SerializeField] private BookProperties _bookProperties;

    public string ShelfName => _bookProperties.ShelfName;
    public Material BookMaterial => _bookProperties.Material;


    void Start()
    {
        _libraryPuzzleController = GameObject.Find("LibraryPuzzles").GetComponent<LibraryPuzzleController>();
        //this.GetComponent<MeshRenderer>().material = BookMaterial;
    }

    public override void LetGo() { 
        base.LetGo();
        
        var didHit = Physics.Raycast(this.transform.position, -this.transform.up, out var hit, 0.5F);
        Debug.Log("let go");
        if(didHit && hit.transform.gameObject.name == ShelfName ){
            /* Book hits shelf */ 
            
            _libraryPuzzleController.SetBook(this.name, ShelfName);
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
