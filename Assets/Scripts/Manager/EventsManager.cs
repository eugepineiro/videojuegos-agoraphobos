using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

// Generate actions and trigger them
public class EventsManager : MonoBehaviour
{
    static public EventsManager instance;
    
    private void Awake() 
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
            
        instance = this; 
    }
    
    #region GAME_EVENTS
    public event Action<bool> OnGameOver; 
    public event Action<PuzzleProperties> OnPuzzleSolved; 

    public void EventGameOver(bool isVictory) 
    { 
        if (OnGameOver != null) OnGameOver(isVictory);
    }

    public void EventPuzzleSolved(PuzzleProperties puzzleProperties){

        if (OnPuzzleSolved != null) OnPuzzleSolved(puzzleProperties);
    }
    #endregion
    
    #region UI_EVENTS

    public event Action<int, int> OnStepSolved;
    public event Action<float, float> OnCharacterLifeChange;
    public event Action<string> OnStoryFrameOpened;

    public void EventStepSolved(int stepsSolved, int totalSteps)
    {
        if (OnStepSolved != null) OnStepSolved(stepsSolved, totalSteps);
    }
    
    public void EventCharacterLifeChange(float currentLife, float maxLife)
    {
        if (OnCharacterLifeChange != null) OnCharacterLifeChange(currentLife, maxLife);
    }
    
    public void EventStoryFrameOpened(string storyFrameName)
    {
        if (OnStoryFrameOpened != null) OnStoryFrameOpened(storyFrameName);
    }
    #endregion
    
    #region SOUND_EVENTS 
    public event Action OnDoorOpened;

    public void EventDoorOpened()
    {
        if (OnDoorOpened != null) OnDoorOpened();
    }

    public event Action OnValveRotated;
    public void EventValveRotated() {
        if (OnValveRotated!= null) OnValveRotated();
    }

    public event Action OnCorrectPipeCombination;
    public void EventCorrectPipeCombination() {
        if (OnCorrectPipeCombination != null) OnCorrectPipeCombination();
    }
    #endregion


}
