using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimatorController : MonoBehaviour
{
    private Animator _animator; 
    private const bool DOOR_PLAY_OPEN_ANIMATION = true;
    private const bool DOOR_PLAY_CLOSE_ANIMATION = false;
    private HallPuzzleController _hallPuzzleController;

    void Start()
    {
        _animator = GetComponent<Animator>();
  		_hallPuzzleController = GameObject.Find("HallPuzzles").GetComponent<HallPuzzleController>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.name == "MansionKey" /*other.CompareTag("Player")*/ )
        {
			Debug.Log("Key hit mansion door");
            SetAnimatorParams(DOOR_PLAY_OPEN_ANIMATION);
            EventsManager.instance.EventDoorOpened(); //Opened door sound
 			_hallPuzzleController.OpenMansionDoor();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetAnimatorParams(DOOR_PLAY_CLOSE_ANIMATION);
        }
    }

    private void SetAnimatorParams(bool performGateOpenAnimation)
    {
        _animator.SetBool("TriggerOpen", performGateOpenAnimation);
        _animator.SetBool("TriggerClose", !performGateOpenAnimation);
        
    }
}
