using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform character;
    public bool interacting { get; }
    public void Interact()
    {
        character.position = new Vector3(-10.2f, 1.29f, 12f);
    }
}
