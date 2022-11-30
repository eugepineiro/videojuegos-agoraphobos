using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontLookDoorAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private bool _fired = false;
    [SerializeField] private string _animationName = "FenceDoorAnimation";

    [SerializeField] public Transform CameraTransform => _cameraTransform;
    [SerializeField] private Transform _cameraTransform;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        RaycastHit hit;
        if (other.CompareTag("Player") && !_fired)
        {
            if (!Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out hit, Mathf.Infinity))
            {
                Debug.Log("Player entered trigger");
                Debug.DrawRay(_cameraTransform.position, _cameraTransform.forward * Mathf.Infinity, Color.green);
                _animator.Play(_animationName, 0, 0.0f);
                EventsManager.instance.EventDoorOpened(); //Opened door sound
                _fired = true;
            }
        }
    }

}
