using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICaster
{
    //float Speed { get; } TODO FLYWEIGHT 

    void Interact(Vector3 direction);
}
