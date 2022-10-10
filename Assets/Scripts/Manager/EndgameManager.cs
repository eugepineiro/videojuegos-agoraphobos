using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndgameManager : MonoBehaviour
{
    [SerializeField] private Image _faceImage; 
    [SerializeField] private Sprite _victorySprite;
    [SerializeField] private Sprite _defeatSprite;   
    [SerializeField] private Text _gameoverText;   

    void Start()
    { 
       
        bool victory = GlobalData.instance.IsVictory;
        //bool victory = true;
        _gameoverText.text = victory ? "WIN!!" : "LOST";

        _faceImage.sprite = victory ? _victorySprite : _defeatSprite;
         
    }   
}
