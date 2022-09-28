using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour, ICaster
{
    // The starting point of the ray in world coordinates.
    private Vector3 origin;

    // The max distance the ray should check for collisions.
    [SerializeField] private float maxDistance = Mathf.Infinity;

    // 	A Layer mask that is used to selectively ignore Colliders when casting a ray.
    [SerializeField] private int layerMask;

    //The direction of the ray.
    private Vector3 direction;

    // 	Specifying queryTriggerInteraction allows you to control whether or not Trigger colliders generate a hit, or whether to use the global Physics.queriesHitTriggers setting..
    [SerializeField] private QueryTriggerInteraction queryTriggerInteraction;

   

    public void Interact()
    {
        // TODO set layer
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;

        origin = transform.position;
        direction = transform.TransformDirection(Vector3.forward);
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(origin, direction, out hit, maxDistance, layerMask))
        {
            Debug.DrawRay(origin, direction * hit.distance, Color.green);
            Debug.Log("Did Hit");
            // to get GameObject hit -> hit.transform.gameObject;
        }
        else
        {
            Debug.DrawRay(origin, direction * 20, Color.red);
            Debug.Log("Did not Hit");
        }
    }
}
