using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Valve : MonoBehaviour, IInteractable
{
    private PuzzleController _puzzleController; 

    [SerializeField] private int _value = 0;

    public AudioClip AudioClip => _audioClip;
    [SerializeField] private AudioClip _audioClip;

    public AudioSource AudioSource => _audioSource;
    private AudioSource _audioSource;

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
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = AudioClip;

        _puzzleController = GetComponent<PuzzleController>();
    }


    public void Interact()
    {
        if (!_interacting) {
            _interacting = false;
            _value = (_value + 1) % 4;
            StartCoroutine(Rotate(transform, new Vector3(_value * 90f, 0, 0)));
            StartCoroutine(Rotate(_associatedPipe.transform, new Vector3(0, _value * 90f, 0)));
            AudioSource.PlayOneShot(AudioClip);
        };
    }
}
