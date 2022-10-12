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
    
    [SerializeField]private GameObject pointer;
    [SerializeField]private Transform camara;
    
    
    // The max distance the ray should check for collisions.
    [SerializeField] private float maxDistance = Mathf.Infinity;
    private ObjectInteracting _objectInteracting;


    struct ObjectInteracting
    {
        public IInteractable script;
        public GameObject gameObject;
    }
    private void Start()
    {
        _objectInteracting = new ObjectInteracting();
        _objectInteracting.gameObject = null;
        _objectInteracting.script = null;
        pointer.SetActive(true);
        
    }

    public void Interact(Vector3 direction)
    {
        if (IsInteracting())
        {
            pointer.SetActive(true);
            _objectInteracting.script.Interact();
            return;
        }
            
        GetObjectInFront(direction);
        if (_objectInteracting.gameObject != null)
        {
            _objectInteracting.script.Interact();
            if (_objectInteracting.script.interacting)
                pointer.SetActive(false);
        }
    }
    private bool IsInteracting()
    {
        return _objectInteracting.script is { interacting: true };
    }
    private void  GetObjectInFront(Vector3 direction)
    {
        _origin = camara.position;
        if (Physics.Raycast(_origin, direction, out var hit, maxDistance))
        {
            
            GameObject objectHit = hit.transform.gameObject;
            Debug.DrawRay(_origin, direction * maxDistance, Color.green);
            
            if (IsInteractable(objectHit))
            {
                _objectInteracting.gameObject = objectHit;
                _objectInteracting.script = objectHit.GetComponent<IInteractable>();
                return;
            }
        }
        Debug.DrawRay(_origin, direction * maxDistance, Color.red);
        _objectInteracting.gameObject = null;
    }

    private bool IsInteractable(GameObject objectHit)
    {
        return objectHit.GetComponent<IInteractable>() != null;
    }
}
