using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdInteract : ICommand
{
    // Propiedades del comando 
    private ICaster _player; 
    private Vector3 _direction; 

    public CmdInteract(ICaster player) { 
        _player = player;
    }

    public void Execute() => _player.Cast();
}
