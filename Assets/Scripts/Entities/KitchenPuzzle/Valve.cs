using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour, IInteractable
{
    private KitchenPuzzleController _kitchenPuzzleController;

    [SerializeField] private int _value = 0;

    public GameObject AssociatedPipe => _associatedPipe;
    [SerializeField] private GameObject _associatedPipe;

    private bool _interacting = false;
    public bool interacting => _interacting;


    Vector3 GetRotationVectorByValue(int value) {
        return new Vector3(value * 90f, 0, 0);
    }

    IEnumerator Rotate(Transform transform, Vector3 rotationVector) {
        Quaternion fromAngle = transform.rotation;
        Quaternion toAngle = Quaternion.Euler(rotationVector);

         for (float t = 0f; t <= 1; t += Time.deltaTime) {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
         }
 
        _interacting = false;
    }

    void Start()
    {
        _kitchenPuzzleController = gameObject.transform.parent.parent.GetComponent<KitchenPuzzleController>();
    }


    public void Interact()
    {
        if (!_interacting) {
            _interacting = false;
            _value = (_value + 1) % 4;
            StartCoroutine(Rotate(transform, new Vector3(_value * 90f, 0, 0)));
            StartCoroutine(Rotate(_associatedPipe.transform, new Vector3(0, _value * 90f, 0)));
            EventsManager.instance.EventValveRotated();
            _kitchenPuzzleController.CheckStepSolved();
        };
    }

    public int GetValue() {
        return _value;
    }
}
