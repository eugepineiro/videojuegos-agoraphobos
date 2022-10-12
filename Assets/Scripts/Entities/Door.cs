using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{ 
    private void OnTriggerEnter(Collider other)
    { 
        Destroy(this.gameObject);
        EventsManager.instance.EventDoorOpened(); //Opened door sound
    }
}
