using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chandelier : MonoBehaviour, IInteractable
{
    private bool _interacting = false;
    public bool interacting => _interacting;

    GameObject chandelier; 

    void Start()
    {
        chandelier = GameObject.Find("Chandelier");
    } 
    
    public void Interact()
    {
        //chandelier.transform.localPosition += new Vector3(transform.localPosition.x,transform.localPosition.y-5,transform.localPosition.z); TODO animation of destoyed chandelier
        Destroy(chandelier);
    }
}
