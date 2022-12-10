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
        print("max chapter is: " + GlobalData.instance.MaxChapter );
        if (GlobalData.instance.MaxChapter == "Laberynth")
        {
            print("yey laberynth");
            GlobalData.instance.SetChapter("Laberynth");
            SceneManager.LoadScene("Laberynth"); 
            SceneManager.LoadScene("LoadbarScene");

            
        }
        else
        {
            print("not done yet");
        }
        
    }

    public void CloseGame() => Application.Quit();
    
}
