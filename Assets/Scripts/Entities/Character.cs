using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Actor
{
     private MovementController _movementController; 
     private InteractController _interactionController; 

    // Travel and Rotation Movement
    [SerializeField] private KeyCode _moveForward = KeyCode.W;
    [SerializeField] private KeyCode _moveBack = KeyCode.S;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;
    
    // Interaction with objects
    [SerializeField] private KeyCode _interact = KeyCode.E;
    [SerializeField] private KeyCode _jump = KeyCode.Space;

    [SerializeField] private const float JUMP_COOLDOWN = 1F;

    private float _jumpTime = JUMP_COOLDOWN;

    [SerializeField] private GameObject _camera;
    private Vector3 _horizontalForward;
    private Vector3 _forward;

    void Start()
    {
        _movementController = GetComponent<MovementController>();
        _interactionController = GetComponent<InteractController>(); 
    }

    void Update()
    {

        if (Input.GetKey(_moveForward))
        {
            _horizontalForward = transform.InverseTransformDirection(new Vector3(_camera.transform.forward.x, 0, _camera.transform.forward.z));
            EventQueueManager.instance.AddCommand(new CmdMovement(_movementController, _horizontalForward));
        }
        if (Input.GetKey(_moveBack))
        {
            _horizontalForward = transform.InverseTransformDirection(new Vector3(_camera.transform.forward.x, 0, _camera.transform.forward.z));
            EventQueueManager.instance.AddCommand(new CmdMovement(_movementController, -_horizontalForward));
        }
        if (Input.GetKey(_moveRight)) {
            Vector3 _horizontalRight = transform.InverseTransformDirection(new Vector3(_camera.transform.right.x, 0, _camera.transform.right.z));
            EventQueueManager.instance.AddCommand(new CmdMovement(_movementController, _horizontalRight)); 
        }
        if (Input.GetKey(_moveLeft))
        {
            Vector3 _horizontalRight = transform.InverseTransformDirection(new Vector3(_camera.transform.right.x, 0, _camera.transform.right.z));
            EventQueueManager.instance.AddCommand(new CmdMovement(_movementController, -_horizontalRight));
        }

        if (Input.GetKeyDown(_jump))
        {
            Debug.Log("Jump");
            if (_jumpTime - Time.deltaTime < 0) {
                Debug.Log("jump pressed");
                _jumpTime = JUMP_COOLDOWN;
                EventQueueManager.instance.AddCommand(new CmdJump(_movementController));
            }
        }

        if (Input.GetKeyDown(_interact))
        {
            _forward = transform.InverseTransformDirection(_camera.transform.forward);
            EventQueueManager.instance.AddCommand(new CmdInteract(_interactionController, _forward));
        }
        _jumpTime -= Time.deltaTime;
    }
}
