using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Actor))]
public class LifeController : MonoBehaviour, IDamageable
{ 
    public float MaxLife => GetComponent<Actor>().ActorStats.MaxLife;
    private float _currentLife;

    private void Start()
    {
        _currentLife = MaxLife;
    }
    public void TakeDamage(float damage)
    {
		 
        _currentLife -= damage;
        EventsManager.instance.EventCharacterLifeChange(_currentLife, MaxLife);
        if (_currentLife <= 0) Die(); 
    }

    public void Die() {  
		EventsManager.instance.EventGameOver(false);
	} 

   
}
