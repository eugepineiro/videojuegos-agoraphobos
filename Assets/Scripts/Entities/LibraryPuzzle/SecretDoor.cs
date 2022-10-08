using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoor : MonoBehaviour,IInteractable
{
    private bool _interacting = false;
    public bool interacting => _interacting;

    void Start()
    {


    }

    // Update is called once per frame
    public void Interact()
    {
          
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z+90); 
        transform.localPosition += new Vector3(transform.localPosition.x-0.5F,transform.localPosition.y+0.5F,0);
    
    }
}
