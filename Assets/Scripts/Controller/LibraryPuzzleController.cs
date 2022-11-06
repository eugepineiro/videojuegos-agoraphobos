using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryPuzzleController : PuzzleController
{
    static public LibraryPuzzleController libraryInstance;
    private Dictionary<string, string> books; // key = book name; value = shelf name
    private int total_books = 3;
    private List<string> correct_books;  
    
        
    // factory pattern (enemy:rat)
    [SerializeField] private Rat ratPrefab;
    private Spawner<Rat> _ratFactory = new Spawner<Rat>();
    public List<Rat> RatInstances => _ratInstances;
    private List<Rat> _ratInstances = new List<Rat>();
    private Transform _ratParent;

    private const int TOTAL_RATS = 5;

    private Vector3 _ratInitialPosition = new Vector3(-18, -3, 15);
    
    
    private void Awake() 
    {
        if(libraryInstance != null) Destroy(this);
        libraryInstance = this; 
    }

    void Start()
    {
        books = new Dictionary<string, string>() { 
            {"BlueBook", "ShelfTop"},
            {"RedBook", "ShelfMiddle"},
            {"GreenBook", "ShelfBottom"}
        };

        correct_books = new List<string>();

        _ratParent = GameObject.Find("Enemies").transform;
        for (int i = 0; i < TOTAL_RATS; i++)
        {
            var rat = _ratFactory.Create(ratPrefab);
            rat.transform.parent = _ratParent;
            rat.transform.position = _ratInitialPosition + new Vector3(0.5F*i,0,0.2F); 
            _ratInstances.Add(rat); 
        }
    }

    public void SetBook(string bookName, string shelfName) 
    {
        if (books[bookName] == shelfName)
        {
            correct_books.Add(bookName);
            base.SolveStep(true);
        } 
        // print("Set book");
        print(correct_books.Count);
        if (correct_books.Count == total_books) {
            base.Solve();
        }
    }

    public void RemoveBook(string bookName) 
    {
        if (correct_books.Contains(bookName))
        {
            correct_books.Remove(bookName);
            base.SolveStep(false);
        }
    }
 
}
