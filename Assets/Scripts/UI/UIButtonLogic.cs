using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonLogic : MonoBehaviour
{
    public void LoadMenuScene() => SceneManager.LoadScene("MenuScene");

    public void LoadLevelScene()
    {
        GlobalData.instance.SetChapter("SampleScene");
        SceneManager.LoadScene("LoadbarScene");
    }

    public void LoadInfoScene() => SceneManager.LoadScene("InformationScene"); 
    
    public void LoadChapterScene() => SceneManager.LoadScene("ChapterScene");

    public void LoadLaberynthScene()
    {
        Debug.Log($"btn labery");
        GlobalData.instance.SetChapter("Laberynth");
        SceneManager.LoadScene("LoadbarScene");

        //SceneManager.LoadScene("Laberynth"); 
    }

    public void CloseGame() => Application.Quit();
    
}
