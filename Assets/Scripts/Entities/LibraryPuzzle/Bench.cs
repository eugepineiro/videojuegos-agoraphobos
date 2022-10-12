using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bench : MonoBehaviour, IInteractable
{
    private bool _interacting = false;
    public bool interacting => _interacting; 

    public void Interact()
    {
        	transform.localPosition += new Vector3(0,0,-0.55F);
    } 
}
