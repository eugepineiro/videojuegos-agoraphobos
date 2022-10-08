using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChessPiece : GrabbableObject
{
     
    
    public override void LetGo() { 
        base.LetGo();
        gameObject.transform.GetComponent<ChessPuzzleController>().DispositionChanged();
    }
    
}
