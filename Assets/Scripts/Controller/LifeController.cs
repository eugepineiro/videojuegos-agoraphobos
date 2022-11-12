using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour, IDamageable
{
    public float MaxLife => _maxLife;
    [SerializeField] private float _maxLife; 
    private float _currentLife;

    private void Start()
    {
        _currentLife = _maxLife;
    }
    public void TakeDamage(float damage)
    {
        _currentLife -= damage;
        EventsManager.instance.EventCharacterLifeChange(_currentLife, _maxLife);
        if (_currentLife <= 0) Die(); 
    }

    public void Die() => EventsManager.instance.EventGameOver(false); 

    private void OnDestroy()
    {
        if (name == "Character") EventsManager.instance.EventGameOver(false);
    }

}
