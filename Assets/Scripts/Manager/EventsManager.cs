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
        if(instance != null) Destroy(this);
        instance = this; 
    }

    public event Action<bool> OnGameOver; 
    public event Action OnPuzzleSolved; 

    public void EventGameOver(bool isVictory) 
    { 
        if (OnGameOver != null) OnGameOver(isVictory);
    }

    public void EventPuzzleSolved(){

        if (OnPuzzleSolved != null) OnPuzzleSolved();
    }
    

    
}
