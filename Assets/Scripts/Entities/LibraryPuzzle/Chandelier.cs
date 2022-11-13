using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chandelier : MonoBehaviour, IInteractable
{
    private bool _interacting = false;
    public bool interacting => _interacting;
    private Animator _animator; 
    private const bool DOOR_PLAY_OPEN_ANIMATION = true;
    private const bool DOOR_PLAY_CLOSE_ANIMATION = false;

    void Start()
    {
        _animator = GameObject.Find("ChandelierAnimator").GetComponent<Animator>();
    } 
    
    public void Interact()
    {
        Debug.Log("Set trigger pull down");
        _animator.SetBool("TriggerPullDown", true);
    }
}
