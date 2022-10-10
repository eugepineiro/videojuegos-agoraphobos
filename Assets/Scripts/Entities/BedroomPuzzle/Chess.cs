using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum PieceType
{
    Empty,
    WPawn,
    WCastle,
    WHorse,
    WBishop,
    WKing,
    WQueen,
    BPawn,
    BCastle,
    BHorse,
    BBishop,
    BKing,
    BQueen
}

public struct Piece
{
    public PieceType Type;
    public string Name;
    public GameObject go;
    public int[] ChessPosition;
}

public class Chess : MonoBehaviour
{
    [SerializeField] List<GameObject> _chessPieces;
    [SerializeField] float _spotSize = 1;

    private List<Piece> _pieces;
// TODO: instance
    private int GetPieceIndexByName(string pieceName)
    {
        return _pieces.FindIndex(piece=> piece.Name.Equals(pieceName));
    }
    
    private void MoveChessPiece(int piece, int x, int z)
    {
        _pieces[piece].go.transform.localPosition = new Vector3(_spotSize * x, 0.5f, _spotSize * z);
        _pieces[piece].ChessPosition[0] = x;
        _pieces[piece].ChessPosition[1] = z;
    }

    public void OnPieceMoved(string pieceName)
    {
        var piece = GetPieceIndexByName(pieceName);
        if(piece == -1)
            return;
        
        var pos = GetPosition(piece);
        print("pos: "+ pos[0] + ","+pos[1]);
        if (pos[0] < 8 && pos[1] < 8)
            SetPieceInTablePosition(piece,  pos[0],  pos[1]);
        else
            RemovePieceFromTable(piece);
    }

    public bool CheckIfInRightPlace(string pieceName)
    {
        var piecei = GetPieceIndexByName(pieceName);
        var piece = _pieces[piecei];
        if (piece.Name.Contains("Bishop"))
            return ((piece.ChessPosition[0] == 2 || piece.ChessPosition[0] == 5) &&
                    (piece.ChessPosition[1] == 0 || piece.ChessPosition[1] == 7));
        if (piece.Name.Contains("Castle"))
            return ((piece.ChessPosition[0] == 0 || piece.ChessPosition[0] == 7) &&
                    (piece.ChessPosition[1] == 0 || piece.ChessPosition[1] == 7));
        if (piece.Name.Contains("Horse"))
            return (piece.ChessPosition[0] == 2 || piece.ChessPosition[0] == 6) &&
                   (piece.ChessPosition[1] == 0 || piece.ChessPosition[1] == 7);
        if (piece.Name.Contains("King") || name.Contains("Queen"))
            return ((piece.ChessPosition[0] == 3 || piece.ChessPosition[0] == 4) &&
                    (piece.ChessPosition[1] == 0 || piece.ChessPosition[1] == 7));
        if (piece.Name.Contains("Pawn"))
            return ((piece.ChessPosition[0] != -1) &&
                    (piece.ChessPosition[1] == 1 || piece.ChessPosition[1] == 6));
        return false;
    }
    

    private void SetPieceInTablePosition(int pieceIndex, int x, int z)
    {
        var piece = _pieces[pieceIndex];
        piece.ChessPosition[0] = x;
        piece.ChessPosition[1] = z;
    }
    private void RemovePieceFromTable(int pieceIndex)
    {
        var piece = _pieces[pieceIndex];
        piece.ChessPosition[0] =-1;
        piece.ChessPosition[1] =-1;
    }
    

    private void Awake()
    {
        _pieces = new List<Piece>();
        InitializePieces();
    }

    private void InitializePieces()
    {
        foreach (var piece in _chessPieces)
        {
            // var o = Instantiate(piece, transform);
            var p = new Piece()
            {
                ChessPosition = GetPosition(piece.transform),
                go = piece,
                Name = piece.name,
                Type = GetTypeByName(piece.name)

            };
            _pieces.Add(p);
        }
    }

    private void ClearPositions()
    {
        foreach (var piece in _pieces)
        {
            piece.ChessPosition[0] = -1;
            piece.ChessPosition[1] = -1;
        }
    }
    private int[] GetPosition(int pieceIndex)
    {
        var position = new int[]{-1,-1};
        if (_pieces[pieceIndex].go.transform.localPosition.y is < 0.6f and > 0.4f)
        {
            var localPosition = _pieces[pieceIndex].go.transform.localPosition;
            var x =(int) (localPosition.x/_spotSize );
            var z = (int) (localPosition.z/_spotSize );
            if (x is < 0 or > 7 && (z is < 0 or > 7))
                return position;
            position[0] = x;
            position[1] = z;
            localPosition = new Vector3(x * _spotSize, localPosition.y, z* _spotSize);
            _pieces[pieceIndex].go.transform.localPosition = localPosition;
        }
        print("new position is: "+ position[0]+", "+position[1]);
        return position;


    }
    private int[] GetPosition(Transform t)
    {
        var position = new int[]{-1,-1};
        if (t.localPosition.y is < 0.6f and > 0.4f)
        {
            var localPosition = t.localPosition;
            var x =(int) (localPosition.x/_spotSize );
            var z = (int) (localPosition.z/_spotSize );
            if (x is < 0 or > 7 && (z is < 0 or > 7))
                return position;
            position[0] = x;
            position[1] = z;
            localPosition = new Vector3(x, localPosition.y, z);
            t.localPosition = localPosition;
        }
        return position;


    }
    

    private PieceType GetTypeByName(string name)
    {
        if (name.Contains("BBishop"))
            return PieceType.BBishop;
        if (name.Contains("BCastle"))
            return PieceType.BCastle;
        if (name.Contains("BHorse"))
            return PieceType.BHorse;
        if (name.Contains("BKing"))
            return PieceType.BKing;
        if (name.Contains("BPawn"))
            return PieceType.BPawn;
        if (name.Contains("BQueen"))
            return PieceType.BQueen;
        if (name.Contains("WBishop"))
            return PieceType.WBishop;
        if (name.Contains("WCastle"))
            return PieceType.WCastle;
        if (name.Contains("WHorse"))
            return PieceType.WHorse;
        if (name.Contains("WKing"))
            return PieceType.WKing;
        if (name.Contains("WPawn"))
            return PieceType.WPawn;
        if (name.Contains("WQueen"))
            return PieceType.WQueen;
        return PieceType.Empty;
    }
    public void RandomizePositions()
    {
        ClearPositions();
        int x;
        int z;
        for (int piece = 0; piece < _pieces.Count; piece++)
        {
            do
            {
                x = Random.Range(2, 6);
                z = Random.Range(2, 6);
            } while (!PositionFree(x, z));
            MoveChessPiece(piece, x, z);
        }

    }
    
    private bool PositionFree(int x, int z)
    {
        var i = _pieces.FindIndex(p => p.ChessPosition[0] == x && p.ChessPosition[1] == z);
        return i == -1;
    }


    public int ChessTableOnInitialDisposition()
    {
        var steps = 0;
        foreach (var piece in _pieces)
        {
            if (piece.Name.Contains("Bishop"))
                if(((piece.ChessPosition[0] == 2 || piece.ChessPosition[0] == 5) &&
                   (piece.ChessPosition[1] == 0 || piece.ChessPosition[1] == 7)))
                    steps++;
            if (piece.Name.Contains("Castle"))
                if(((piece.ChessPosition[0] == 0 || piece.ChessPosition[0] == 7) &&
                     (piece.ChessPosition[1] == 0 || piece.ChessPosition[1] == 7)))
                    steps++;
            if (piece.Name.Contains("Horse"))
                if(((piece.ChessPosition[0] == 2 || piece.ChessPosition[0] == 6) &&
                     (piece.ChessPosition[1] == 0 || piece.ChessPosition[1] == 7)))
                    steps++;
            if (piece.Name.Contains("King") || name.Contains("Queen"))
                if(((piece.ChessPosition[0] == 3 || piece.ChessPosition[0] == 4) &&
                     (piece.ChessPosition[1] == 0 || piece.ChessPosition[1] == 7)))
                    steps++;
            if (piece.Name.Contains("Pawn"))
                if (((piece.ChessPosition[0] != -1) &&
                      (piece.ChessPosition[1] == 1 || piece.ChessPosition[1] == 6)))
                    steps++;
        }
        return steps;
    }

}
