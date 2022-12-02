using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class ChapterManager : MonoBehaviour
{
     
    static public ChapterManager instance;

    [SerializeField] private Button _secondChapterBtn;
    [SerializeField] private GameObject _secondChapterLock;

    private const int FIRST_CHAPTER_PUZZLES = 4;
    private void Awake() 
    {
        if(instance != null) Destroy(this);
        instance = this; 
    }

    void Start()
    {

        if (GlobalData.instance.PuzzlesSolved == FIRST_CHAPTER_PUZZLES)
        {
            _secondChapterLock.SetActive(false);
            _secondChapterBtn.interactable = true;
        }
        else
        {
            _secondChapterBtn.interactable = false;
        }
        
    }
    private void OnPuzzleSolved(PuzzleProperties puzzleProperties)
    {
        Debug.Log("chapter manager");
        if (puzzleProperties.Id == "THE MAZE")
        {
            Debug.Log("chapter manager interactable");
            _secondChapterLock.SetActive(false);
            _secondChapterBtn.interactable = true;
        }
    }
}
