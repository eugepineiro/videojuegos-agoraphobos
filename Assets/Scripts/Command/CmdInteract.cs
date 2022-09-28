using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdInteract : ICommand
{
    // Propiedades del comando 
    private ICaster _interactor;

    public CmdInteract(ICaster interactor) { 
        _interactor = interactor;
    }

    public void Execute() => _interactor.Interact();
}
