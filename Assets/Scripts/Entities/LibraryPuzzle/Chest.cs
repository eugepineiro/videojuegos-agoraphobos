using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private PuzzleController _puzzleController; 
    [SerializeField] private KeyCode _interact = KeyCode.I;

    void Start()
    {
        _puzzleController = GetComponent<PuzzleController>();
        



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(_interact)) { 
            transform.rotation = Quaternion.Euler(transform.rotation.x-45, transform.rotation.y, transform.rotation.z);  
        } 
    }
}
