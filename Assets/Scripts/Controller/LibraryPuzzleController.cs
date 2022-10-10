using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryPuzzleController : PuzzleController
{
    private Dictionary<string, string> books; // key = book name; value = shelf name
    private int total_books = 3;
    private List<string> correct_books;  

    void Start()
    {
        books = new Dictionary<string, string>() { 
            {"BlueBook", "ShelfTop"},
            {"RedBook", "ShelfMiddle"},
            {"GreenBook", "ShelfBottom"}
        };

        correct_books = new List<string>();
    }

    public void SetBook(string bookName, string shelfName) 
    {   
        if (books[bookName] == shelfName) correct_books.Add(bookName); 
        // print("Set book");
        print(correct_books.Count);
        if (correct_books.Count == total_books) {
            base.Solve();
        }
    }

    public void RemoveBook(string bookName) 
    {   
        if (correct_books.Contains(bookName)) correct_books.Remove(bookName);
    }
 
}
