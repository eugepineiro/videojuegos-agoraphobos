using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeButton : MonoBehaviour, IInteractable
{
    private bool _interacting = false;
    public bool interacting => _interacting;

    [SerializeField] private Material _material;
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private int _angle;

    private GameObject _maze;
    private GameObject _mazePuzzle;

    void Start()
    {
        _maze = GameObject.Find("Maze");
        _mazePuzzle = GameObject.Find("MazePuzzle");
    } 
    
    public void Interact()
    { 
        _maze.GetComponent<Renderer>().material = _material;  
        _mazePuzzle.transform.localRotation = Quaternion.Euler(0, _angle, 0);
        _nextButton.SetActive(true);
    }
}
