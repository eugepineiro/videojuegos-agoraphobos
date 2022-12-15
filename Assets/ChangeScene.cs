using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private int time =20;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(passiveMe(time));
    }
    
 
    IEnumerator passiveMe(int secs)
    {
        yield return new WaitForSeconds(secs);
        SceneManager.LoadScene("MenuScene");
        
    }
}
