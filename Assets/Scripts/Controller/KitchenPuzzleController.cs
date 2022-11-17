using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenPuzzleController : PuzzleController
{
    static public KitchenPuzzleController kitchenInstance;
    // [SerializeField] private int _step = 1;  
    private Dictionary<int, Color> _puzzleColorByStep;

    private string[] RED_COMBINATIONS = new string[] {
        "0*2*0",
        "2*2*0",
        "0**12",
        "0**32",
        "2**12",
        "2**32"
    };

    private string[] BLUE_COMBINATIONS = new string[] {
        "12***",
        "32***",
    };

    private string[] GREEN_COMBINATIONS = new string[] {
        "0**1*",
        "2**1*",
        "0**3*",
        "2**3*",
    };

    private const int TOTAL_PIPES = 5;

    private Dictionary<int, string[]> _puzzleCombinationsByStep;

    private void Awake()
    {
        if (kitchenInstance != null) Destroy(this);
        kitchenInstance = this;
    }

    public void CheckStepSolved()
    {
        if (base.GetStepsSolved() < base.TotalSteps)
        {
            Valve[] valves = gameObject.GetComponentsInChildren<Valve>();
            IList<int> values = new List<int>();

            foreach (Valve valve in valves)
            {
                values.Add(valve.GetValue());
            }
            CheckPipes(values);
        }
    }

    private void CheckPipes(IList<int> pipeValues)
    {
        string[] combinations = _puzzleCombinationsByStep[GetStepsSolved()];
        bool currentStepSolved = false;
        foreach (string combination in combinations)
        {
            if (currentStepSolved)
            {
                break;
            }
            int numberOfCorrectPipes = 0;

            for (int i = 0; i < TOTAL_PIPES; i++)
            {
                if (pipeValues[i].ToString().Equals(combination[i].ToString()) || combination[i].Equals('*'))
                {
                    numberOfCorrectPipes++;
                }
            }

            if (numberOfCorrectPipes == TOTAL_PIPES)
            {
                currentStepSolved = true;
                // _step++;
                base.SolveStep(true);

                UpdateCapsuleColor(GetPuzzleColor());
                EventsManager.instance.EventCorrectPipeCombination();

                if (base.GetStepsSolved() < base.TotalSteps)
                {
                    CheckStepSolved();
                }
                else
                {
                    base.Solve();
                }
                break;
            }
        }
    }

    private void UpdateCapsuleColor(Color emissionColor)
    {
        GameObject capsule = this.transform.Find("Capsule").gameObject;
        capsule.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        capsule.GetComponent<Renderer>().material.SetColor("_EmissionColor", emissionColor);
    }

    void Start()
    {
        _puzzleColorByStep = new Dictionary<int, Color> {
            {0, new Color(0.4f, 0.003f, 0.003f)},
            {1, new Color(0.003f, 0.003f, 0.4f)},
            {2, new Color(0.003f, 0.4f, 0.003f)},
            {3, Color.black},
        };
        _puzzleCombinationsByStep = new Dictionary<int, string[]> {
            {0, RED_COMBINATIONS },
            {1, BLUE_COMBINATIONS},
            {2, GREEN_COMBINATIONS},
            {3, null},
        };
    }

    public Color GetPuzzleColor()
    {
        return _puzzleColorByStep[base.GetStepsSolved()];
    }

}