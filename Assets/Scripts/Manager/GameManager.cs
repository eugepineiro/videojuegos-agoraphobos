using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isGameOver = false; // triggers game over logic 
    [SerializeField] private bool _isVictory = false;  // win or lose 
    [SerializeField] private Text _gameoverMessage;
    [SerializeField] private int _maxTime = 10;
    private int puzzlesSolved = 0;
    private int totalPuzzles = 3;
    
    void Start()
    {
        EventsManager.instance.OnGameOver += OnGameOver; // suscripcion a nuestro evento
        EventsManager.instance.OnPuzzleSolved += OnPuzzleSolved;
        _gameoverMessage.text = string.Empty;
        //StartCoroutine(TimeFinished(_maxTime));
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

        _gameoverMessage.text = isVictory ? "WIN" : "LOSE"; 
        _gameoverMessage.color = isVictory ? Color.cyan : Color.red; 
        
    }

    private void OnPuzzleSolved() 
    {
        puzzlesSolved+=1;
        if(puzzlesSolved == totalPuzzles)
            _isVictory = true;
            EventsManager.instance.EventGameOver(_isVictory);
        // TODO: cambio de escena etc
        
    }
    

}
