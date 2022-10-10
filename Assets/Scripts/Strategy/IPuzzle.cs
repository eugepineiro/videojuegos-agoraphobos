using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPuzzle 
{
   bool IsSolved { get; }
   int StepsSolved { get; }
   void Solve();
   void SolveStep(bool isCorrect);
}
