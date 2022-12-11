using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeButton : MonoBehaviour, IInteractable
{
    private bool _interacting = false;
    public bool interacting => _interacting;

    [SerializeField] private Material _material; 
	[SerializeField] private Vector3 _newCharacterPosition;	

    private GameObject _maze;
    private GameObject _character;

    void Start()
    {
        _maze = GameObject.Find("Maze");
        _character = GameObject.Find("Character");
    } 
    
    public void Interact()
    { 
        _maze.GetComponent<Renderer>().material = _material;   
		_character.transform.position = _newCharacterPosition;
    }
}
