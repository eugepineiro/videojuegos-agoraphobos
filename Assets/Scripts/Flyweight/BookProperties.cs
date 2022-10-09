using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Book", menuName = "Objects/Book", order = 0 /*primero*/)] // creable desde unity 
public class BookProperties : ScriptableObject
{
    [SerializeField] private BookValues _bookValues;

    public GameObject Shelf => _bookValues.Shelf; 
    public Texture Texture => _bookValues.Texture;
}

[System.Serializable]
public struct BookValues
{
    public GameObject Shelf; 
    public Texture Texture;
}