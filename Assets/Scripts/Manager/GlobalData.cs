using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    // Data que no se destruye al cambiar de scene
    static public GlobalData instance; 

    public bool IsVictory => _isVictory;
    [SerializeField] private bool _isVictory;
    
    public string Chapter => _chapter;
    [SerializeField] private string _chapter;

    private void Awake()
    { 
        if (instance != null) Destroy(this.gameObject); 
        instance = this; 

        DontDestroyOnLoad(this);
    }

    public void SetVictoryField(bool isVictory) => _isVictory = isVictory;
    
    public void SetChapter(string chapter) => _chapter = chapter;
}
