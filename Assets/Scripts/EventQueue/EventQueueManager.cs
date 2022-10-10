using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventQueueManager : MonoBehaviour
{
    //Singleton
    static public EventQueueManager instance; 

    public Queue<ICommand> Events => _events;
    private Queue<ICommand> _events = new Queue<ICommand>(); 

    [SerializeField] private bool _isPlayerFrozen;

    private void Awake() 
    { 
        if (instance != null) Destroy(this); 
        instance = this;
    }

    private void Update() 
    { 
        while (_events.Count > 0)
        {
            var command = _events.Dequeue();
            if(_isPlayerFrozen && command is CmdMovement) { 
                continue; // si esta congelado no se deberia poder mover, me salteo esos eventos
            }
            command.Execute();

        } 
        _events.Clear();
         
    }

    public void AddCommand(ICommand command) => _events.Enqueue(command);
}
