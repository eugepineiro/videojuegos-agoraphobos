using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : GrabbableObject
{
    [SerializeField] private string _mansionDoorName;
    private HallPuzzleController _hallPuzzleController;

    void Start()
    {
        _hallPuzzleController = GameObject.Find("HallPuzzles").GetComponent<HallPuzzleController>(); 
    }

    public override void LetGo() { 
        base.LetGo();
        
        var didHit = Physics.Raycast(this.transform.position, -this.transform.up, out var hit, 5F);
      
        Debug.DrawRay(this.transform.position, -this.transform.up * 5F, Color.green,3);
       
        if(didHit && hit.transform.gameObject.name == _mansionDoorName ){
            /* Key hits mansion door */ 
            Debug.Log("Key hits mansion door ");
            _hallPuzzleController.OpenMansionDoor();
        }
    }
}
