using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
     private MovementController _movementController; 
     private InteractController _interactionController; 

    // Travel and Rotation Movement
    [SerializeField] private KeyCode _moveForward = KeyCode.W;
    [SerializeField] private KeyCode _moveBack = KeyCode.S;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;
    [SerializeField] private KeyCode _interact = KeyCode.E;

    // Commands
    private CmdMovement _cmdMoveForward;
    private CmdMovement _cmdMoveBack;
    private CmdMovement _cmdRotateLeft;
    private CmdMovement _cmdRotateRight;
    private CmdInteract _cmdInteract;

    void Start()
    {
        _movementController = GetComponent<MovementController>();
        _interactionController = GetComponent<InteractController>();
        //_cmdMoveForward = new CmdMovement(_movementController, Vector3.forward);
        //_cmdMoveBack = new CmdMovement(_movementController,-Vector3.forward);
        _cmdRotateLeft = new CmdMovement(_movementController,Vector3.left);
        _cmdRotateRight = new CmdMovement(_movementController,Vector3.right);
        _cmdInteract = new CmdInteract(_interactionController);
        
    }

    void Update()
    {

        if (Input.GetKey(_moveForward))
        {
            Vector3 horizontalForward = transform.InverseTransformDirection(new Vector3(transform.forward.x, 0, transform.forward.z));
            EventQueueManager.instance.AddCommand(new CmdMovement(_movementController, horizontalForward));
        }
        if (Input.GetKey(_moveBack))
        {
            Vector3 horizontalForward = transform.InverseTransformDirection(new Vector3(transform.forward.x, 0, transform.forward.z));
            EventQueueManager.instance.AddCommand(new CmdMovement(_movementController, -horizontalForward));
        }
        if (Input.GetKey(_moveRight))   EventQueueManager.instance.AddCommand(_cmdRotateRight);
        if (Input.GetKey(_moveLeft))    EventQueueManager.instance.AddCommand(_cmdRotateLeft); 
        if (Input.GetKey(_interact))    EventQueueManager.instance.AddCommand(_cmdInteract); 
    }
}
