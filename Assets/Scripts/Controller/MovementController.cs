using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour, IMoveable
{
    [SerializeField] private ActorStats _actorStats;
    public float Speed =>_actorStats.MovementSpeed; 
    //[SerializeField] private float _speed = 5;

    public float RotationSpeed => _actorStats.RotationSpeed; 
    //[SerializeField] private float _rotationSpeed = 20;
   
    public void Travel(Vector3 direction) => transform.Translate(direction * Time.deltaTime * Speed); // called by cmdMovement

    public void Rotate(Vector3 direction) => transform.Rotate(direction * Time.deltaTime * RotationSpeed);
}
