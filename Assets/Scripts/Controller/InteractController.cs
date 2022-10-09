using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractController : MonoBehaviour, ICaster
{
    // The starting point of the ray in world coordinates.
    private Vector3 _origin;
    private GameObject _gameObjectInteracting;
    [SerializeField]private GameObject pointer;
    [SerializeField]private Transform camara;
    
    // The max distance the ray should check for collisions.
    [SerializeField] private float maxDistance = Mathf.Infinity;

    private const int Interactable = 6;

    // 	Specifying queryTriggerInteraction allows you to control whether or not Trigger colliders generate a hit, or whether to use the global Physics.queriesHitTriggers setting..
    [SerializeField] private QueryTriggerInteraction queryTriggerInteraction;

    private void Start()
    {
        _gameObjectInteracting = null;
        pointer.SetActive(true);
    }

    public void Interact(Vector3 direction)
    {
        pointer.SetActive(false);
        if(IsInteracting())
        {
            StopInteracting();
            return;
        }
        
        _origin = camara.position;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(_origin, direction, out var hit, maxDistance))
        {
            Debug.DrawRay(_origin, direction * hit.distance, Color.green);
            Debug.Log("Did Hit");
            if(hit.transform.gameObject.layer == Interactable)
            {
                StartInteracting(hit);
            }
            
        }
        else
        {
            Debug.DrawRay(_origin, direction * 20, Color.red);
            Debug.Log("Did not Hit");
        }
    }

    private bool IsInteracting()
    {
        return _gameObjectInteracting != null && _gameObjectInteracting.GetComponent<IInteractable>().interacting;
    }

    private void StopInteracting()
    {
        _gameObjectInteracting.GetComponent<IInteractable>().Interact();
        _gameObjectInteracting = null;
        pointer.SetActive(true);
    }

    private void StartInteracting(RaycastHit hit)
    {
        _gameObjectInteracting = hit.transform.gameObject;
        _gameObjectInteracting.GetComponent<IInteractable>().Interact();
    }

    private void Update()
    {
        if (IsInteracting())
        {
            
            PlaceObjectForward();
        }

        ShowRaycastCenter();

    }

    private void PlaceObjectForward()
    {
        
    }

    private void ShowRaycastCenter()
    {
        pointer.SetActive(true);
    }
}
