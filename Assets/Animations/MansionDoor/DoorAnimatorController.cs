using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimatorController : MonoBehaviour
{
    private Animator _animator; 
    private const bool DOOR_PLAY_OPEN_ANIMATION = true;
    private const bool DOOR_PLAY_CLOSE_ANIMATION = false;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("Player") )
        {
            SetAnimatorParams(DOOR_PLAY_OPEN_ANIMATION);
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
