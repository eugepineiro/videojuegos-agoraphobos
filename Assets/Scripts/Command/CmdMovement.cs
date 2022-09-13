using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdMovement : ICommand
{
    // Propiedades del comando 
    private IMoveable _moveable; 
    private Vector3 _direction; 

    public CmdMovement(IMoveable moveable, Vector3 direction) { 
        _moveable = moveable;
        _direction = direction;
    }

    public void Execute() => _moveable.Travel(_direction);
}
