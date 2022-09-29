using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chess : MonoBehaviour
{
    enum Pieces
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

    private Pieces[,] _chessTable = new Pieces[8, 8];
    [SerializeField] List<GameObject> _chessPieces;
    [SerializeField] float _spotSize = 1;
    public void MoveChessPiece(int piece, int x, int z)
    {
        _chessPieces[piece].transform.localPosition = new Vector3(_spotSize * x, 1, _spotSize * z);
        _chessTable[x, z] = GetPieceValue(piece);
    }

    private Pieces GetPieceValue(int piece)
    {
        switch (piece)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
                return Pieces.WPawn;
            case 8:
            case 9:
                return Pieces.WCastle;
            case 10:
            case 11:
                return Pieces.WHorse;
            case 12:
            case 13:
                return Pieces.WBishop;
            case 14:
                return Pieces.WKing;
            case 15:
                return Pieces.WQueen;
            case 16:
            case 17:
            case 18:
            case 19:
            case 20:
            case 21:
            case 22:
            case 23:
                return Pieces.BPawn;
            case 24:
            case 25:
                return Pieces.BCastle;
            case 26:
            case 27:
                return Pieces.BHorse;
            case 28:
            case 29:
                return Pieces.BBishop;
            case 30:
                return Pieces.BKing;
            case 31:
                return Pieces.BQueen;

        }
        return 0;
    }

    public void RandomizePositions()
    {
        CleanChessTable();
        int x;
        int z;
        for (int piece = 1; piece < 32; piece++)
        {
            do
            {
                x = Random.Range(0, 8);
                z = Random.Range(0, 8);
            } while (!PositionFree(x, z));

            MoveChessPiece(piece, x, z);
        }

    }
    
    private bool PositionFree(int x, int z) => _chessTable[x, z] == 0;

    private void CleanChessTable()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                _chessTable[i, j] = Pieces.Empty;
            }
        }
    }

    //public Vector3 GetPiecePosition(int piece)
    //{
    //    if(_chessPieces[piece].transform.localPosition.x <= 7 && _chessPieces[piece].transform.localPosition.z <= 7 && _chessPieces[piece].transform.localPosition.z == 0)
    //    {
    //        return _chessPieces[piece].transform.localPosition;
    //    }
    //    return new Vector3(-1, -1, -1);
    //}

    public bool ChessTableOnInitialDisposition()
    {

        return true;
    }

}
