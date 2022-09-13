using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
     private MovementController _movementController; 

    // Travel and Rotation Movement
    [SerializeField] private KeyCode _moveForward = KeyCode.W;
    [SerializeField] private KeyCode _moveBack = KeyCode.S;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;

    // Commands
    private CmdMovement _cmdMoveForward;
    private CmdMovement _cmdMoveBack;
    private CmdRotation _cmdRotateLeft;
    private CmdRotation _cmdRotateRight;

    void Start()
    {
        _movementController = GetComponent<MovementController>();
        _cmdMoveForward = new CmdMovement(_movementController, Vector3.forward);
        _cmdMoveBack = new CmdMovement(_movementController,-Vector3.forward);
        
        _cmdRotateLeft = new CmdRotation(_movementController,-Vector3.up);
        _cmdRotateRight = new CmdRotation(_movementController,Vector3.up);
        
    }

    void Update()
    {
        if (Input.GetKey(_moveForward)) EventQueueManager.instance.AddCommand(_cmdMoveForward);
        if (Input.GetKey(_moveBack))    EventQueueManager.instance.AddCommand(_cmdMoveBack);
        if (Input.GetKey(_moveRight))   EventQueueManager.instance.AddCommand(_cmdRotateRight);
        if (Input.GetKey(_moveLeft))    EventQueueManager.instance.AddCommand(_cmdRotateLeft); 
    }
}
