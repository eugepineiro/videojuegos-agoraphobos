using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChessPiece : GrabbableObject
{
    private ChessPuzzleController _chessPuzzleController;
    [SerializeField] private string name;
    private void Start()
    {
        _chessPuzzleController = gameObject.transform.GetComponent<ChessPuzzleController>();
    }

    public override void LetGo() { 
        base.LetGo();
        _chessPuzzleController.ChessPieceMoved(transform.localPosition, name);
    }
    
}
