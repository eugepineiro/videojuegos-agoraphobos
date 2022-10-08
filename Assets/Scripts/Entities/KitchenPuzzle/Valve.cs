using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Valve : MonoBehaviour
{
    private PuzzleController _puzzleController; 
    [SerializeField] private KeyCode _interact = KeyCode.V;
    [SerializeField] private bool _rotating = false;
    [SerializeField] private int _value = 0;

    public AudioClip AudioClip => _audioClip;
    [SerializeField] private AudioClip _audioClip;

    public AudioSource AudioSource => _audioSource;
    private AudioSource _audioSource;


    Vector3 GetRotationVectorByValue(int value) {
        return new Vector3(value * 90f, 0, 0);
    }

    IEnumerator Rotate(Vector3 rotationVector) {
        Quaternion fromAngle = transform.rotation;
        Quaternion toAngle = Quaternion.Euler(rotationVector);

         for (float t = 0f; t <= 1; t += Time.deltaTime) {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
         }
 
        _rotating = false;
    }

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = AudioClip;

        _puzzleController = GetComponent<PuzzleController>();
    }

    void Update()
    { 
        if (Input.GetKeyDown(_interact) && !_rotating) {
            _rotating = true;
            _value = (_value + 1) % 4; 
            StartCoroutine(Rotate(GetRotationVectorByValue(_value)));
            AudioSource.PlayOneShot(AudioClip);
        };
    }
}
