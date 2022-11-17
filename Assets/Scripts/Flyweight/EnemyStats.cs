using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Objects/Enemy", order = 0 /*primero*/)] // creable desde unity 
public class EnemyStats : ScriptableObject
{
    [SerializeField] private EnemyValues _enemyValues;
    
    public float ChaseDistance => _enemyValues.ChaseDistance;
    public int Damage => _enemyValues.Damage;

}

[System.Serializable]
public struct EnemyValues
{
    public float ChaseDistance; 
    public int Damage; 
}