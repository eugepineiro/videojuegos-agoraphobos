using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{ 
    IEnumerator Rotate(Transform transform, Vector3 rotationVector) {
        Debug.Log("Called coroutine");
        Quaternion fromAngle = transform.localRotation;
        Quaternion toAngle = Quaternion.Euler(rotationVector);

         for (float t = 0f; t <= 1; t += Time.deltaTime) {
            transform.localRotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
         }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered collision");
        if ( other.CompareTag("Player") ) {
            Vector3 localRotation = transform.localEulerAngles;
            Debug.Log($"local rotation is {localRotation.y}");
            StartCoroutine(Rotate(transform, new Vector3(localRotation.x, localRotation.y + 90f, localRotation.z)));
            GetComponent<Collider>().enabled = false;
        } 
        EventsManager.instance.EventDoorOpened(); //Opened door sound
    }
}
