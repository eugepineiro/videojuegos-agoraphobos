using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPuzzle 
{
   bool IsSolved { get; }
   void Solve(); 
}
