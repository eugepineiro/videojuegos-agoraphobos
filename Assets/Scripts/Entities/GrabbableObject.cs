using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour, IGrabbable
{
    private bool _interacting = false;
    public bool interacting => _interacting;
    public Transform camera;

    public virtual void Grab(){
        //todo
        _interacting = true;
        
    }
    public virtual void LetGo(){
        // todo
        _interacting = false;
    }
    
    public void Interact()
    {
        if (interacting)
        {
            
            Debug.Log("i let go the object");
            LetGo();
        }
        else
        {
            Debug.Log("i grabbed the object");
            Grab();
        }
        
    }

    void Update() { 
        if(interacting)
            transform.position = camera.position + camera.forward * 1;
    }
    
}
