using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    private Transform _destination;

    void Start()
    {
        _destination = GameObject.Find("Character").transform;
    }
    void Update()
    {
        Vector3 direction = _destination.position - transform.position;
        
        Quaternion targetRotation = Quaternion.LookRotation(-direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime); //smooth rotation 
    }
}
