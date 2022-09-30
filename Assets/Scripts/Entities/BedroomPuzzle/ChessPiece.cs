using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChessPiece : MonoBehaviour, IInteractable
{
    private bool _interacting = false;
    public bool interacting => _interacting;
    [SerializeField] private string _scriptName;

    public void Interact()
    {
        if (interacting)
        {
            _interacting = false;
            print("i let go the chess piece");
        }
        else
        {
            print("i grabbed the chess piece");
            _interacting = true;
        }
        
    }
}
