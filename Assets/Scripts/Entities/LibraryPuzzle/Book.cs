using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
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
        if (Input.GetKey(_interact)) transform.localPosition += new Vector3(0,2,0);
    }
}
