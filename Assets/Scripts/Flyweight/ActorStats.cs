using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActorStats", menuName = "Objects/Stats", order = 0 /*primero*/)] // creable desde unity 
public class ActorStats : ScriptableObject
{
    [SerializeField] private StatValues _statValues;
    
    public int MaxLife => _statValues.MaxLife;
    public float MovementSpeed => _statValues.MovementSpeed;
    public float RotationSpeed => _statValues.RotationSpeed;

}

[System.Serializable]
public struct StatValues
{
    public int MaxLife; 
    public float MovementSpeed;
    public float RotationSpeed;
}