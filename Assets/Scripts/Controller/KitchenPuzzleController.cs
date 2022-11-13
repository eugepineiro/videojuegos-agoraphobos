using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenPuzzleController : PuzzleController
{
    static public KitchenPuzzleController kitchenInstance;
    [SerializeField] private int _step = 1;  
    private Dictionary<int, Color> _puzzleColorByStep;

    private string[] RED_COMBINATIONS = new string[] {
        "1*2*3",
        "3*2*3",
        "1**01",
        "1**21",
        "3**01",
        "3**21"
    };

    private string[] BLUE_COMBINATIONS = new string [] {
        "00***",
        "20***",
    };

    private string[] GREEN_COMBINATIONS = new string[] {
        "1**0*",
        "3**0*",
        "1**2*",
        "3**2*",
    };

    private Dictionary<int, string[]> _puzzleCombinationsByStep;

    private void Awake() {
        if(kitchenInstance != null) Destroy(this);
        kitchenInstance = this; 
    }

    public void CheckStepSolved() {
        Valve[] valves = gameObject.GetComponentsInChildren<Valve>();
        IList<int> values = new List<int>();

        foreach(Valve valve in valves) {
            values.Add(valve.GetValue());
        }

        CheckPipes(values);
    }

    private void CheckPipes(IList<int> pipeValues) {
        string[] combinations = _puzzleCombinationsByStep[_step];
        bool currentStepSolved = false;
        foreach(string combination in combinations) {
            if (currentStepSolved) {
                break;
            }
            int numberOfCorrectPipes = 0;

            for (int i = 0; i < 5; i++) {
                if (pipeValues[i].ToString().Equals(combination[i].ToString()) || combination[i].Equals('*')) {
                    numberOfCorrectPipes++;
                }
            }
            
            if (numberOfCorrectPipes == 5) {
                currentStepSolved = true;
                _step++;
                base.SolveStep(true);

                UpdateCapsuleColor(_step <= 3 ? GetPuzzleColor() : Color.black);
                EventsManager.instance.EventCorrectPipeCombination();
                
                if (_step <= 3) {
                    CheckStepSolved();
                }
                break;
            }
        }
    }

    private void UpdateCapsuleColor(Color emissionColor) {
        GameObject capsule = this.transform.Find("Capsule").gameObject;
        capsule.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        capsule.GetComponent<Renderer>().material.SetColor("_EmissionColor", emissionColor);
    }

    void Start()
    {  
        _puzzleColorByStep = new Dictionary<int, Color> {
            {1, Color.red},
            {2, Color.blue},
            {3, Color.green},
        };
        _puzzleCombinationsByStep  = new Dictionary<int, string[]> {
            {1, RED_COMBINATIONS },
            {2, BLUE_COMBINATIONS},
            {3, GREEN_COMBINATIONS},
        };
    }

    public Color GetPuzzleColor() {
        return _puzzleColorByStep[_step];
    }
 
}