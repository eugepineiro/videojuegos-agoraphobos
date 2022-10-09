using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InteractController : MonoBehaviour, ICaster
{
    // The starting point of the ray in world coordinates.
    private Vector3 _origin;
    [SerializeField] private int forwardBuffer;
    private GameObject _gameObjectInteracting;
    [SerializeField]private GameObject pointer;
    [SerializeField]private Transform camara;
    private bool _interacting;
    
    // The max distance the ray should check for collisions.
    [SerializeField] private float maxDistance = Mathf.Infinity;

    // 	Specifying queryTriggerInteraction allows you to control whether or not Trigger colliders generate a hit, or whether to use the global Physics.queriesHitTriggers setting..
    [SerializeField] private QueryTriggerInteraction queryTriggerInteraction;

    private void Start()
    {
        _gameObjectInteracting = null;
        pointer.SetActive(true);
        _interacting = false;
    }

    public void Interact(Vector3 direction)
    {
        // print("interact is called");
        if (IsInteracting())
        {
            StopInteracting();
            return;
        }
            
        GameObject objectToInteract = GetObjectInFront(direction);
        if (objectToInteract != null)
        {
            if (IsGrabbable(objectToInteract))
                Grab(objectToInteract);
            InteractWithObject(objectToInteract);
        }
    }

    private void Grab(GameObject o)
    {
        _gameObjectInteracting = o;
        _gameObjectInteracting.GetComponent<Rigidbody>().detectCollisions = false;
        _gameObjectInteracting.GetComponent<Rigidbody>().useGravity = false;
        pointer.SetActive(false);
        _interacting = true;
        print("start interacting");
    }

    private void InteractWithObject(GameObject o)
    {
        o.GetComponent<IInteractable>().Interact();
    }

    private bool IsGrabbable(GameObject o)
    {
        return o.GetComponent<IGrabbable>() != null;
    }
    private bool IsInteracting()
    {
        return _interacting;
    }

    private void StopInteracting()
    {
        print("stop interacting");
        _gameObjectInteracting.GetComponent<Rigidbody>().detectCollisions = true;
        _gameObjectInteracting.GetComponent<Rigidbody>().useGravity = true;
        _gameObjectInteracting = null;
        pointer.SetActive(true);
        _interacting = false;
    }
    
    [CanBeNull]
    private GameObject  GetObjectInFront(Vector3 direction)
    {
        _origin = camara.position;
        if (Physics.Raycast(_origin, direction, out var hit, maxDistance))
        {
            
            GameObject objectHit = hit.transform.gameObject;
            // print(objectHit.name);
            Debug.DrawRay(_origin, direction * maxDistance, Color.green);
            
            if (IsInteractable(objectHit))
            {
                // print("hit interactable");
                return objectHit;
            }
            // print("hit non interactable");
        }
        Debug.DrawRay(_origin, direction * maxDistance, Color.red);
        // Debug.Log("Did not Hit");
        return null;

    }

    private bool IsInteractable(GameObject objectHit)
    {
        // print(objectHit.name);
        return objectHit.GetComponent<IInteractable>() != null;
    }

    private void Update()
    {
        if (IsInteracting())
        {
            PlaceCurrentObjectInFront();
        }
            
    }

    private void PlaceCurrentObjectInFront()
    {
        var point = GetRaycastCollision();
        if (point != null)
        {
            pointer.SetActive(false);
            var buffer = _gameObjectInteracting.GetComponent<IGrabbable>().positionBuffer;
            _gameObjectInteracting.transform.position = (Vector3)point +  buffer;
            return;
        }
        SetInteractingObjectNearMe();
    }

    private void SetInteractingObjectNearMe()
    {
        pointer.SetActive(true);
        _gameObjectInteracting.transform.position = transform.forward + gameObject.transform.forward * forwardBuffer;
    }
    
    private Vector3? GetRaycastCollision()
    {
        if (Physics.Raycast(_origin, camara.forward, out var hit, maxDistance))
        {
            if (hit.normal == new Vector3(0, 1, 0)) ;
                return hit.point;
        }
        return null;
    }
}
