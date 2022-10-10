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


    private void Start()
    {
        _gameObjectInteracting = null;
        pointer.SetActive(true);
        _interacting = false;
    }

    public void Interact(Vector3 direction)
    {
        if (IsInteracting())
        {
            LetGo();
            return;
        }
            
        GameObject objectToInteract = GetObjectInFront(direction);
        if (objectToInteract != null)
        {
            if (IsGrabbable(objectToInteract))
            {
                Grab(objectToInteract);
                return; 
            }
                
            InteractWithObject(objectToInteract);
        }
    }

    private void Grab(GameObject o)
    {
        _gameObjectInteracting = o;
        Rigidbody rb = _gameObjectInteracting.GetComponent<Rigidbody>();
        rb.detectCollisions = false;
        rb.useGravity = false;
        pointer.SetActive(false);
        _interacting = true;
        _gameObjectInteracting.GetComponent<IGrabbable>().Grab();
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

    private void LetGo()
    {
        _gameObjectInteracting.GetComponent<IGrabbable>().LetGo();
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
            Debug.DrawRay(_origin, direction * maxDistance, Color.green);
            
            if (IsInteractable(objectHit))
            {
                return objectHit;
            }
        }
        Debug.DrawRay(_origin, direction * maxDistance, Color.red);
        return null;

    }

    private bool IsInteractable(GameObject objectHit)
    {
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
        var ctransform = camara.transform;
        _gameObjectInteracting.transform.position = ctransform.position + ctransform.forward * forwardBuffer;
    }
    
    private Vector3? GetRaycastCollision()
    {
        if (Physics.Raycast(_origin, camara.forward, out var hit, maxDistance))
        {
            return hit.point;
            var r = hit.transform.rotation;
            var vector = Quaternion.AngleAxis(r.y, Vector3.up) * Quaternion.AngleAxis(r.z, Vector3.forward) * Quaternion.AngleAxis(r.x, Vector3.right)* hit.normal ;
            print(vector);
            if (vector.y.Equals(1f))
            {
                print("mira para arriba");
                
            }
                
        }
        return null;
    }
}
