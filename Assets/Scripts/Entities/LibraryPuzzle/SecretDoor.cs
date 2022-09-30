using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoor : MonoBehaviour
{
    private PuzzleController _puzzleController; 
    [SerializeField] private KeyCode _interact = KeyCode.O;

    void Start()
    {
        _puzzleController = GetComponent<PuzzleController>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(_interact)) { 
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z+90); 
            transform.localPosition += new Vector3(transform.localPosition.x-0.5F,transform.localPosition.y+0.5F,0);
        }
    }
}
