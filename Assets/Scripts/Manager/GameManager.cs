using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isVictory = false;  // win or lose 
    private int _maxTime = 10;//30*60; // TODO chequear cuantos mins queremos
    private int puzzlesSolved = 0;
    private int totalPuzzles = 2;
    //private PuzzleProperties currentPuzzle;
    
    
    
    void Start()
    {
        //currentPuzzle = puzzles.Dequeue();
        EventsManager.instance.OnGameOver += OnGameOver; // suscripcion a nuestro evento
        EventsManager.instance.OnPuzzleSolved += OnPuzzleSolved;
        StartCoroutine(TimeFinished(_maxTime));
    }
    
 
    IEnumerator TimeFinished(int time)
    {
        yield return new WaitForSeconds(time);
        // todo si no se destruye game manager al cambiar de escena entonces 
        // hay que cambiar esto, se lanzaria dos veces sino
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
        Debug.Log("SOLVED");
        Debug.Log("PUZZLES SOLVED");
        Debug.Log(puzzlesSolved);
        
        if(puzzlesSolved == totalPuzzles){
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
        foreach (var door in doorNames) GameObject.Find(door).GetComponent<BoxCollider>().isTrigger = true;
    }

    public int GetMaxTime()
    {
        return _maxTime;
    }
}
