using UnityEngine;

public class ChessPiece : GrabbableObject
{
    private ChessPuzzleController _chessPuzzleController;
    private void Start()
    {
        _chessPuzzleController = gameObject.transform.parent.GetComponent<ChessPuzzleController>();
    }

    public override void LetGo() { 
        base.LetGo();
        print("let go");
        _chessPuzzleController.ChessPieceMoved(name);
    }
}