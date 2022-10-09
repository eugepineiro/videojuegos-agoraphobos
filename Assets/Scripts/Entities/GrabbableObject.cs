using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour, IGrabbable
{
    private bool _interacting = false;
    public bool interacting => _interacting;
    public Transform camera;

    private Vector3 _positionBuffer = new Vector3(0, 0.1f, 0);
    public Vector3 positionBuffer => _positionBuffer;

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
            
            // Debug.Log("i let go the object");
            LetGo();
        }
        else
        {
            // Debug.Log("i grabbed the object");
            Grab();
        }
        
    }
    
}
