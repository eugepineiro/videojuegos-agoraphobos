using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdJump : ICommand
{
    // Propiedades del comando 
    private IMoveable _moveable;

    public CmdJump(IMoveable moveable)
    {
        _moveable = moveable;
    }

    public void Execute() => _moveable.Jump();
}
