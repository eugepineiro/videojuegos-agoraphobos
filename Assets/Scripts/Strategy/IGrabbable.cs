using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrabbable : IInteractable
{

    void Grab(); 
    void LetGo();
}
