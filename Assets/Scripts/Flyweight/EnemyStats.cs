using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Objects/Enemy", order = 0 /*primero*/)] // creable desde unity 
public class EnemyStats : ScriptableObject
{
    [SerializeField] private EnemyValues _enemyValues;
    
    public float ChaseDistance => _enemyValues.ChaseDistance;
    public int Damage => _enemyValues.Damage;
    public float Speed => _enemyValues.Speed;

}

[System.Serializable]
public struct EnemyValues
{
    public float ChaseDistance; 
    public int Damage;
    public float Speed;
}