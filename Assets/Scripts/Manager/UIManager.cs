using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    
    /* Image Referece */
    [SerializeField] private Image _lifebar;
    [SerializeField] private GameObject _storyFrame;
    
    /* Story Frames*/
    [SerializeField] private Sprite _kitchenStoryFrame;
    
    /* Text Reference */
    [SerializeField] private TextMeshProUGUI _steps;
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private TextMeshProUGUI _time;
    [SerializeField] private TextMeshProUGUI _levelAnimation;

    private Animator _animator;

    private float timeRemaining; 

    private void Start()
    {
		timeRemaining = GlobalData.instance.MaxMinutes * 60;
        Debug.Log($"TIME REIMAINGN {timeRemaining}");
        _level.text = $"Level {GlobalData.instance.PuzzlesSolved+1} of {GameManager.instance.GetTotalPuzzles()}";
        _storyFrame.SetActive(false);
        _animator = _levelAnimation.GetComponent<Animator>();
        //_animator.SetBool("isNewLevel", true); 
        _animator.Play("Base Layer.levelTextBegin", 0, 0.25f);
        /* Subscribe to events */ 
        EventsManager.instance.OnPuzzleSolved += OnPuzzleSolved;
        EventsManager.instance.OnStepSolved += OnStepSolved;
        EventsManager.instance.OnCharacterLifeChange += OnCharacterLifeChange;
        EventsManager.instance.OnStoryFrameOpened += OnStoryFrameOpened;
    }

    private void OnStepSolved(int stepsSolved, int totalSteps)
    {
        _steps.text = $"{stepsSolved} of {totalSteps}";
    } 
    
    private void OnPuzzleSolved(PuzzleProperties puzzleProperties)
    {
        _level.text = $"Level {puzzleProperties.Level + 1} of {GameManager.instance.GetTotalPuzzles()}";
        _steps.text = "0";
        _levelAnimation.text = $"LEVEL {puzzleProperties.Level + 1}\n{puzzleProperties.Id}";
        _animator.SetBool("isNewLevel", true);
        _animator.Play("Base Layer.levelTextBegin", 0, 0.25f);
    }
    
    private void OnCharacterLifeChange(float currentLife, float maxLife)
    {
        _lifebar.fillAmount = currentLife / maxLife;
    }
    
    private void OnStoryFrameOpened(string storyFrameName)
    {
        _storyFrame.SetActive(true);
        Debug.Log("Set active");
        if (storyFrameName == "KitchenStoryFrame")
        {
            Debug.Log("image");
            _storyFrame.GetComponent<Image>().sprite = _kitchenStoryFrame;
        }
    }
    private void Update()
    {
        if (timeRemaining > 0)
        {
            float minutes = Mathf.Floor(timeRemaining / 60);
            float seconds = timeRemaining%60;
            _time.text = $"Time Left {minutes}:{Mathf.RoundToInt(seconds)}";
            timeRemaining -= Time.deltaTime;
        }
        
    }

}