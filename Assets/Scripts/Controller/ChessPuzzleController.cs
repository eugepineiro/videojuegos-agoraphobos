
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ChessPuzzleController : PuzzleController
{
    private Chess _chess;

    
    // factory pattern (enemy:rat)
    [SerializeField] private Enemy spiderPrefab;
    private Spawner<Enemy> _SpiderFactory = new Spawner<Enemy>();
    public List<Enemy> SpiderInstances => _spiderInstances;
    private List<Enemy> _spiderInstances = new List<Enemy>();
    private Transform _spiderParent;

    private const int TOTAL_SPIDERS = 5;

    
    private List<Vector3> _spiderInitialPosition = new List<Vector3>(){new Vector3(4.7F,0F,3.9F), 
        new Vector3(-2f,0f,-1.17f),
        new Vector3(3.448f,0f,2f),
        new Vector3(2f,0f,2.63f),
        new Vector3(1.8f,0f,-1.41f)
    };
    
    private void Awake()
    {
        _chess = GetComponent<Chess>();
    }

    private void Start()
    {
        _chess.RandomizePositions();
        
        _spiderParent = GameObject.Find("Enemies").transform;
        for (int i = 0; i < TOTAL_SPIDERS; i++)
        {
            var rat = _SpiderFactory.Create(spiderPrefab);
            rat.transform.parent = _spiderParent;
            rat.transform.position = _spiderInitialPosition[i]; 
            _spiderInstances.Add(rat); 
        }
    }


    public void ChessPieceMoved(string pieceName)
    {
        _chess.OnPieceMoved(pieceName);
        var steps = _chess.ChessTableOnInitialDisposition();

        SolveStep(steps);
        if(steps == TotalSteps)
            Solve();
    }
    
    
    public bool CheckSolved() => _chess.ChessTableOnInitialDisposition() == TotalSteps;
}
