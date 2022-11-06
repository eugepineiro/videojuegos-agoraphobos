using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager instance; 
    [SerializeField] private bool _isVictory = false;  // win or lose 
    [SerializeField] private int _maxMinutes = 30;
    private float _maxTime;  // lose if time is over
    private int puzzlesSolved = 0;
    [SerializeField] private int _totalPuzzles = 2;

    private void Awake() 
    {
        if(instance != null) Destroy(this);
        instance = this; 
    }
    void Start()
    {
        _maxTime = _maxMinutes * 60;
        EventsManager.instance.OnGameOver += OnGameOver; // subscribe to event 
        EventsManager.instance.OnPuzzleSolved += OnPuzzleSolved;
        StartCoroutine(TimeFinished(_maxTime));
    }

    IEnumerator TimeFinished(float time)
    {
        yield return new WaitForSeconds(time);
        EventsManager.instance.EventGameOver(_isVictory);
    }
    
    private void OnGameOver(bool isVictory) 
    {
        _isVictory = isVictory; 
        GlobalData.instance.SetVictoryField(_isVictory);

        Invoke("LoadEndgameScene",3);
    }

    private void OnPuzzleSolved(PuzzleProperties puzzleProperties) 
    {
        puzzlesSolved+=1;
   
        if(puzzlesSolved == _totalPuzzles){
            _isVictory = true;
            EventsManager.instance.EventGameOver(_isVictory);
        } else
        {
            OpenDoors(puzzleProperties.DoorsToOpen);
        }
        
    }

    private void LoadEndgameScene() => SceneManager.LoadScene("EndgameScene");

    private void OpenDoors(List<string> doorNames)
    {
        Debug.Log(doorNames);
        foreach (var door in doorNames) GameObject.Find(door).GetComponent<BoxCollider>().isTrigger = true;
    }

    public float GetMaxTime()
    {
        return _maxTime;
    }
    
    public float GetTotalPuzzles()
    {
        return _totalPuzzles;
    }
}
