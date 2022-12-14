using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSolved : MonoBehaviour
{
    private bool _isSolved = false;
    [SerializeField] private string objectName;
    [SerializeField] private MazePuzzleController _mazePuzzleController;
    [SerializeField] private int correctX;
    [SerializeField] private int correctY;
    [SerializeField] private int correctZ;
    [SerializeField] private int incorrectX;
    [SerializeField] private int incorrectY;
    [SerializeField] private int incorrectZ;
    private Vector3 _correctPos;
    private Vector3 _incorrectPos;
    private void Start()
    {
        _correctPos = new Vector3(correctX, correctY, correctZ);
        _incorrectPos = new Vector3(incorrectX, incorrectY, incorrectZ);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if ((!_isSolved) && other.name == objectName)
        {
            _isSolved = true;
            _mazePuzzleController.SolveStep(true);
            if (this.name == "Maze")
            {
                _mazePuzzleController.Solve();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_isSolved && other.name == objectName)
        {
            var position = other.transform.position;
            var isWrongPos = Vector3.Distance(_correctPos, position) >
                             Vector3.Distance(_incorrectPos, position);
            if (isWrongPos)
            {
                _mazePuzzleController.SolveStep(false);
                _isSolved = false;
            }
        }
    }
}
