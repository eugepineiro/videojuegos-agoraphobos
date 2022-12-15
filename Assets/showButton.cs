using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(GlobalData.instance.IsVictory);
    }
}
