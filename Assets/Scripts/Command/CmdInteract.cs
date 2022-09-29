using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdInteract : ICommand
{
    // Propiedades del comando 
    private ICaster _interactor;

    private Vector3 _direction;

    public CmdInteract(ICaster interactor, Vector3 direction) { 
        _interactor = interactor;
        _direction = direction;
    }

    public void Execute() => _interactor.Interact(_direction);
}
