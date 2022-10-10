using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.name == "Character")
        Destroy(this.gameObject);
        EventsManager.instance.EventDoorOpened();
    }
}
