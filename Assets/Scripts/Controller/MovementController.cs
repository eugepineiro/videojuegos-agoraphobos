using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour, IMoveable
{
    // public float Speed => GetComponent<Actor>().ActorStats.MovementSpeed;TODO FLYWEIGHT
    [SerializeField] private float _speed = 5;

    // public float RotationSpeed => GetComponent<Actor>().ActorStats.RotationSpeed; TODO FLYWEIGHT
    [SerializeField] private float _rotationSpeed = 20;
   
    public void Travel(Vector3 direction) => transform.Translate(direction * Time.deltaTime * _speed); // called by cmdMovement

    public void Rotate(Vector3 direction) => transform.Rotate(direction * Time.deltaTime * _rotationSpeed);
}
