using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrabbable : IInteractable
{
    Vector3 positionBuffer { get; }
    void Grab(); 
    void LetGo();
}
