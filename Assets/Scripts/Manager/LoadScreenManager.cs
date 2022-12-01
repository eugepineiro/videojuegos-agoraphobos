using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class LoadScreenManager : MonoBehaviour
{
    [SerializeField] private Image _progressBar; 
    [SerializeField] private TextMeshProUGUI _progressValue;
    /*public string TargetScene => _targetScene; 
    [SerializeField] private string _targetScene; */
    static public LoadScreenManager instance;
    
    private void Awake() 
    {
        if(instance != null) Destroy(this);
        instance = this; 
    }

    void Start()
    {
        string targetScene = GlobalData.instance.Chapter;
        StartCoroutine(LoadAsync(targetScene));
        
    }
    
   /* public void SetTargetScene(string targetScene)
    {
        Debug.Log($"Set targe scene to {targetScene} ");
        _targetScene = targetScene;
    } */
    IEnumerator LoadAsync(string targetScene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(targetScene);
        float progress = 0;
        
        while (!operation.isDone)
        {
            progress = operation.progress;
            _progressBar.fillAmount = progress; // [0;1] 
            _progressValue.text = $"Loading ... {Math.Truncate(progress * 100)}%";
            
            yield return null;  // se libera frame a frame 
        }
    }

   
}
