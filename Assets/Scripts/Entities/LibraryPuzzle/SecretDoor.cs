using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoor : MonoBehaviour,IInteractable
{
    private bool _interacting = false;
    public bool interacting => _interacting;
	
	GameObject secretDoor;  

	void Start()
    {
        secretDoor = GameObject.Find("SecretDoor");
    }

    public void Interact()
    {
        Destroy(secretDoor);
    }
}
