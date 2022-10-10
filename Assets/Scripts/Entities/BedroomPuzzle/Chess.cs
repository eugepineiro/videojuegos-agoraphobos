using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
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
    public Transform transform;
    public int[] ChessPosition;
}

public class Chess : MonoBehaviour
{
    [SerializeField] List<GameObject> _chessPieces;
    [SerializeField] float _spotSize = 1;

    private List<Piece> _pieces;

    private int GetPieceIndexByName(string pieceName)
    {
        return _pieces.FindIndex(piece=> piece.Name == pieceName);
    }
    
    private void MoveChessPiece(int piece, int x, int z)
    {
        _pieces[piece].transform.localPosition = new Vector3(_spotSize * x, 0.5f, _spotSize * z);
        _pieces[piece].ChessPosition[0] = x;
        _pieces[piece].ChessPosition[1] = z;
    }

    public void OnPieceMoved(string pieceName)
    {
        var piece = GetPieceIndexByName(pieceName);
        var pos = GetPosition(_pieces[piece].transform);
        
        if (pos[0] < 8 && pos[1] < 8)
            SetPieceInTablePosition(piece,  pos[0],  pos[1]);
        else
            RemovePieceFromTable(piece);
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
            var p = new Piece()
            {
                ChessPosition = GetPosition(piece.transform),
                transform = piece.transform,
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
    private int[] GetPosition(Transform t)
    {
        var position = new int[]{-1,-1};
        if (t.localPosition.y < 0.5f && t.localPosition.y > 0.4f)
        {
            var localPosition = t.localPosition;
            var x =(int) (localPosition.x / _spotSize);
            var z = (int) (localPosition.z / _spotSize);
            position[0] = x;
            position[1] = z;
            localPosition = new Vector3(x, localPosition.y, z);
            t.localPosition = localPosition;
        }
        print("new position is: "+ position);
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
                x = Random.Range(0, 8);
                z = Random.Range(0, 8);
            } while (!PositionFree(x, z));
            MoveChessPiece(piece, x, z);
        }

    }
    
    private bool PositionFree(int x, int z)
    {
        var i = _pieces.FindIndex(p => p.ChessPosition[0] == x && p.ChessPosition[1] == z);
        return i == -1;
    }


    public bool ChessTableOnInitialDisposition()
    {
        foreach (var piece in _pieces)
        {
            if (name.Contains("Bishop"))
                if(!((piece.ChessPosition[0] == 2 || piece.ChessPosition[0] == 5) &&
                   (piece.ChessPosition[1] == 0 || piece.ChessPosition[1] == 7)))
                    return false;
            if (name.Contains("Castle"))
                if(!((piece.ChessPosition[0] == 0 || piece.ChessPosition[0] == 7) &&
                     (piece.ChessPosition[1] == 0 || piece.ChessPosition[1] == 7)))
                    return false;
            if (name.Contains("Horse"))
                if(!((piece.ChessPosition[0] == 2 || piece.ChessPosition[0] == 6) &&
                     (piece.ChessPosition[1] == 0 || piece.ChessPosition[1] == 7)))
                    return false;
            if (name.Contains("King") || name.Contains("Queen"))
                if(!((piece.ChessPosition[0] == 3 || piece.ChessPosition[0] == 4) &&
                     (piece.ChessPosition[1] == 0 || piece.ChessPosition[1] == 7)))
                    return false;
            if (name.Contains("Pawn"))
                if (!((piece.ChessPosition[0] != -1) &&
                      (piece.ChessPosition[1] == 1 || piece.ChessPosition[1] == 6)))
                    return false;
        }
        return true;
    }

}
