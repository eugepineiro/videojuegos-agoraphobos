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
    [SerializeField] private string _targetScene = "SampleScene"; 
    
    void Start()
    {
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_targetScene);
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
