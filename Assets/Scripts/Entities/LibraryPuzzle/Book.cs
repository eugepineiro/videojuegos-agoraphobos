using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : GrabbableObject
{
    private LibraryPuzzleController _libraryPuzzleController;
    [SerializeField] private BookProperties _bookProperties;
    public string ShelfName => _bookProperties.ShelfName;
    //public Material BookMaterial => _bookProperties.Material;

    void Start()
    {
        _libraryPuzzleController = GameObject.Find("LibraryPuzzles").GetComponent<LibraryPuzzleController>();
        //this.GetComponent<MeshRenderer>().material = BookMaterial;
    }

    public override void LetGo() { 
        base.LetGo();
        
        var didHit = Physics.Raycast(this.transform.position, -this.transform.up, out var hit, 5F);
      
        Debug.DrawRay(this.transform.position, -this.transform.up * 5F, Color.green,3);
        if(didHit) Debug.Log(hit.transform.gameObject.name);
        if(didHit && hit.transform.gameObject.name == ShelfName ){
            /* Book hits shelf */ 
            Debug.Log("Book hits shelf ");
            _libraryPuzzleController.SetBook(this.name, ShelfName);
        }
    }

    public override void Grab() { 
        base.Grab();
        _libraryPuzzleController.RemoveBook(this.name);
    }
}
