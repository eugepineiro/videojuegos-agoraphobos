using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPuzzle 
{
   
   string puzzleId { get; }
   
   bool IsSolved { get; }

   GameObject PuzzleObject { get; }

   void Solve(); 
}
