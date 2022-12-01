using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryFrame : MonoBehaviour,IInteractable
{
    private bool _interacting = false;
    public bool interacting => _interacting;
    void Start()
    {
        
    }

    public void Interact()
    {
        Debug.Log("Interacting with story frame");
        EventsManager.instance.EventStoryFrameOpened(this.gameObject.name);
         
    }
}
