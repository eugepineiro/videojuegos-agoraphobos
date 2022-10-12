using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour, IGrabbable
{
    private bool _interacting = false;
    public bool interacting => _interacting;
    private Transform camara;
    private float maxDistanceLetGo = 2;
    private float forwardBuffer = 1;

    [SerializeField]private Vector3 _positionBuffer = new Vector3(0, 0.1f, 0);
    public Vector3 positionBuffer => _positionBuffer;

    private void Awake()
    {
        camara = GameObject.Find("Main Camera").transform;
    }

    public virtual void Grab(){
        _interacting = true;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.detectCollisions = false;
        rb.useGravity = false;
    }
    
    public virtual void LetGo(){
        _interacting = false;
        gameObject.GetComponent<Rigidbody>().detectCollisions = true;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
    
    public void Interact()
    {
        if (interacting)
        {   
            Debug.Log("i let go the object");
            LetGo();
        }
        else
        {
            Debug.Log("i grabbed the object");
            Grab();
        }
        
    }

    private void Update()
    {
        if (_interacting)
        {
            PlaceInFrontCamera();
        }
    }
    private void PlaceInFrontCamera()
    {
        var point = GetRaycastCollision();
        if (point != null)
        {
            transform.position = (Vector3)point +  positionBuffer;
            return;
        }
        SetNearCamara();
    }

    private void SetNearCamara()
    {
        gameObject.transform.position = camara.position + camara.forward * forwardBuffer;

    }

    private Vector3? GetRaycastCollision()
    {
        if (Physics.Raycast(camara.position, camara.forward, out var hit, maxDistanceLetGo))
        {
            Debug.DrawRay(camara.position, camara.forward * maxDistanceLetGo, Color.green);
            var r = hit.transform.rotation;
            var vector = Quaternion.AngleAxis(-r.y, Vector3.up) * Quaternion.AngleAxis(-r.z, Vector3.forward) * Quaternion.AngleAxis(-r.x, Vector3.right)* hit.normal ;
            if (Math.Abs(vector.y - 1) < 0.1f)
            {
                return hit.point;
                
            }
                
        }
        Debug.DrawRay(camara.position, camara.forward * maxDistanceLetGo, Color.red);
        return null;
    }
}
