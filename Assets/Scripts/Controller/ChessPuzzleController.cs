
using System;

public class ChessPuzzleController : PuzzleController
{
    private Chess _chess;

    private void Awake()
    {
        _chess = GetComponent<Chess>();
    }

    private void Start()
    {
        _chess.RandomizePositions();
    }


    public void ChessPieceMoved(string pieceName)
    {
        _chess.OnPieceMoved(pieceName);
        if (_chess.CheckIfInRightPlace(pieceName))
            SolveStep();
        else
            SolveStep();
        if (StepsSolved == TotalSteps)
            Solve();
    }
    
    
    public bool CheckSolved() => _chess.ChessTableOnInitialDisposition();
}
