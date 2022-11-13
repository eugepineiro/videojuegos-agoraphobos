using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoor : MonoBehaviour,IInteractable
{
    private bool _interacting = false;
    public bool interacting => _interacting;
    private Animator _animator; 
    private const bool DOOR_PLAY_OPEN_ANIMATION = true;
    private const bool DOOR_PLAY_CLOSE_ANIMATION = false;
	
	private GameObject secretDoor;  

	void Start()
    {
        _animator = GetComponent<Animator>();
        secretDoor = GameObject.Find("SecretDoorPivot");
    }

    public void Interact()
    {
        Debug.Log("Interacting with secret door");
        if (secretDoor.transform.rotation.x == 0)
        {
            SetAnimatorParams(DOOR_PLAY_OPEN_ANIMATION);
            Debug.Log("Playing open aanim");
        }
        else
        {
            SetAnimatorParams(DOOR_PLAY_CLOSE_ANIMATION);
            Debug.Log("Playing close aanim");
        }
        
    }
    
    private void SetAnimatorParams(bool performGateOpenAnimation)
    {
        _animator.SetBool("TriggerOpen", performGateOpenAnimation);
        _animator.SetBool("TriggerClose", !performGateOpenAnimation);
        
    }
}
