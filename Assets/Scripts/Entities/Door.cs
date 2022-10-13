using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{ 
    IEnumerator Rotate(Transform transform, Vector3 rotationVector) {
        Debug.Log("Called coroutine");
        Quaternion fromAngle = transform.rotation;
        Quaternion toAngle = Quaternion.Euler(rotationVector);

         for (float t = 0f; t <= 1; t += Time.deltaTime) {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
         }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered collision");
        if ( other.CompareTag("Player") ) 
            StartCoroutine(Rotate(transform, new Vector3(0, 90f, 0)));
            GetComponent<Collider>().enabled = false;
        EventsManager.instance.EventDoorOpened(); //Opened door sound
    }
}
