using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonLogic : MonoBehaviour
{

    public void LoadMenuScene() => SceneManager.LoadScene("MenuScene");

    public void LoadLevelScene() => SceneManager.LoadScene("SampleScene");

    public void LoadInfoScene() => Debug.Log("Infor screen"); //SceneManger.LoadScene("InformationScene"); TODO 

    public void CloseGame() => Application.Quit();
    
}
