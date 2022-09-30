using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour, ICaster
{
    // The starting point of the ray in world coordinates.
    private Vector3 _origin;
    private GameObject _gameObjectInteracting = null;


    // The max distance the ray should check for collisions.
    [SerializeField] private float _maxDistance = Mathf.Infinity;

    // 	A Layer mask that is used to selectively ignore Colliders when casting a ray.
    [SerializeField] private int _layerMask;

    private int INTERACTABLE = 6;

    // 	Specifying queryTriggerInteraction allows you to control whether or not Trigger colliders generate a hit, or whether to use the global Physics.queriesHitTriggers setting..
    [SerializeField] private QueryTriggerInteraction queryTriggerInteraction;

   

    public void Interact(Vector3 direction)
    {
        if(_gameObjectInteracting != null && _gameObjectInteracting.GetComponent<IInteractable>().interacting)
        {
            _gameObjectInteracting.GetComponent<IInteractable>().Interact();
            _gameObjectInteracting = null;
            return;
        }
        // TODO set layer
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;

        _origin = transform.position;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(_origin, direction, out hit, _maxDistance, layerMask))
        {
            Debug.DrawRay(_origin, direction * hit.distance, Color.green);
            Debug.Log("Did Hit");
            if(hit.transform.gameObject.layer == INTERACTABLE)
            {
                _gameObjectInteracting = hit.transform.gameObject;
                _gameObjectInteracting.GetComponent<IInteractable>().Interact();
            }
            
        }
        else
        {
            Debug.DrawRay(_origin, direction * 20, Color.red);
            Debug.Log("Did not Hit");
        }
    }
}
