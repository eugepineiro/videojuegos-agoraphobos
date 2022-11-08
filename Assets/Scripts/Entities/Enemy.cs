using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	
	public int Damage => _damage; 
	[SerializeField] private int _damage = 10;

	public Collider collider => _collider; 
	[SerializeField] private Collider _collider;

	public Rigidbody rigidBody => _rigidBody; 
	[SerializeField] private Rigidbody _rigidBody;

	[SerializeField] private List<int> _layerTarget;
	
    public void OnTriggerEnter(Collider collider) 
	{ 
		Debug.Log("Enemy collided with smth");
		if(collider.gameObject.name == "Character") { 
			Debug.Log("Enemy collided with character");
			IDamageable damageable = collider.GetComponent<IDamageable>();
			damageable?.TakeDamage(_damage);
		}
	}	
	
	public void Start() 
	{	 
		_rigidBody = GetComponent<Rigidbody>(); 
		_collider = GetComponent<Collider>();

		_collider.isTrigger = true; 
		_rigidBody.useGravity = false;  
		_rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
		
	} 
}
