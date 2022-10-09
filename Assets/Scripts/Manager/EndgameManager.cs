using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndgameManager : MonoBehaviour
{
    /*[SerializeField] private Image _background;
    [SerializeField] private Sprite _victorySprite;
    [SerializeField] private Sprite _defeatSprite; */ 

    void Start()
    { 
        Text title = GameObject.Find("TitleText").GetComponent<Text>();
        title.text = GlobalData.instance.IsVictory ? "YOU'VE ESCAPED!!" : "LOST";
    }
}
