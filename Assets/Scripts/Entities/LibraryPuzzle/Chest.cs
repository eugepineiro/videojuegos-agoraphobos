using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    private bool _interacting = false;
    public bool interacting => _interacting;
 
    public void Interact()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x-45, transform.rotation.y, transform.rotation.z);      
    }
}
