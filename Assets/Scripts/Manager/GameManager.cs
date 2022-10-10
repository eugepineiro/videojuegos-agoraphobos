using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isGameOver = false; // triggers game over logic 
    [SerializeField] private bool _isVictory = false;  // win or lose 
    [SerializeField] private Text _gameoverMessage;
    private int _maxTime = 30*60; // TODO chequear cuantos mins queremos
    private int puzzlesSolved = 0;
    private int totalPuzzles = 1;
    
    
    void Start()
    {
        EventsManager.instance.OnGameOver += OnGameOver; // suscripcion a nuestro evento
        EventsManager.instance.OnPuzzleSolved += OnPuzzleSolved;
        _gameoverMessage.text = string.Empty;
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
        _isGameOver = true; 
        _isVictory = isVictory; 
        GlobalData.instance.SetVictoryField(_isVictory);

        _gameoverMessage.text = isVictory ? "WIN" : "LOSE"; 
        _gameoverMessage.color = isVictory ? Color.cyan : Color.red; 

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
        // TODO: cambio de escena etc
        } else
        {
            OpenDoors(puzzleProperties.DoorsToOpen); // TODO libraryDOOR ES PARAM
            //GameObject.Find("BedroomDoor").SetActive(true);
        }
        
    }

    private void LoadEndgameScene() => SceneManager.LoadScene("EndgameScene");

    private void OpenDoors(List<string> doorNames)
    {
        foreach (var door in doorNames) GameObject.Find(door).SetActive(false);
    }
}
