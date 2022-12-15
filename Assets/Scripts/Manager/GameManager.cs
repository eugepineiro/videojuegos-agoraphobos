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
    [SerializeField] private int _totalPuzzles = 6;
    
    private const int FIRST_CHAPTER_PUZZLES = 4;

    private void Awake() 
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this; 
        // DontDestroyOnLoad(gameObject);
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
        Debug.Log("Son puzzle solvewd");
        puzzlesSolved = GlobalData.instance.PuzzlesSolved +1;
        Debug.Log($"Solved {GlobalData.instance.PuzzlesSolved} puzzles");
        GlobalData.instance.SetPuzzlesSolved(puzzlesSolved);
		if (GlobalData.instance.PuzzlesSolved == FIRST_CHAPTER_PUZZLES-1) GameObject.Find("HallPuzzles").transform.GetChild(0).gameObject.SetActive(true); // final puzzle needs mansion key
        
        if(GlobalData.instance.PuzzlesSolved == FIRST_CHAPTER_PUZZLES) StartCoroutine(LoadSecondChapterScene());
        Debug.Log($"PUZZLES SOLVED {GlobalData.instance.PuzzlesSolved} >= TROTAL PUZEL {_totalPuzzles}");
		if(GlobalData.instance.PuzzlesSolved >= _totalPuzzles){
            _isVictory = true;
            EventsManager.instance.EventGameOver(_isVictory);
        } else
        {
            OpenDoors(puzzleProperties.DoorsToOpen);
        }
    }

    private void LoadEndgameScene() => SceneManager.LoadScene("EndgameScene");

    private IEnumerator LoadSecondChapterScene()
    {
        yield return new WaitForSeconds(4);
        GlobalData.instance.SetChapter("Laberynth");
        GlobalData.instance.SetMaxChapter("Laberynth");
        SceneManager.LoadScene("Laberynth");
        
    }

    private void OpenDoors(List<string> doorNames)
    {
        Debug.Log(doorNames);
        foreach (var door in doorNames) GameObject.Find(door).GetComponent<BoxCollider>().isTrigger = true;
    }
    private void SpawnEnemies(List<string> doorNames)
    {
        
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
