using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Book", menuName = "Objects/Book", order = 0 /*primero*/)] // creable desde unity 
public class BookProperties : ScriptableObject
{
    [SerializeField] private BookValues _bookValues;

    public string ShelfName => _bookValues.ShelfName; 
    public Material Material => _bookValues.Material;
}

[System.Serializable]
public struct BookValues
{
    public string ShelfName; 
    public Material Material;
}