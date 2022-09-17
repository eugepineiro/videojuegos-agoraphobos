using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour, IPuzzle
{

    public bool IsSolved => _isSolved;
    [SerializeField] private bool _isSolved = false;

    public GameObject PuzzleObject => _puzzleObject;
    [SerializeField] private GameObject _puzzleObject;

    public void Solve() => _isSolved = true;
}