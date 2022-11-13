using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chandelier : MonoBehaviour, IInteractable
{
    private bool _interacting = false;
    public bool interacting => _interacting;
    private Animator _animator; 

    void Start()
    {
        _animator = GameObject.Find("ChandelierAnimator").GetComponent<Animator>();
    } 
    
    public void Interact()
    { 
        _animator.SetBool("TriggerPullDown", true);
    }
}
