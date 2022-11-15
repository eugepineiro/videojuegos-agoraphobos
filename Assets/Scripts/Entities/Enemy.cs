using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	private NavMeshAgent _navMeshAgent;
	private bool _chasing;
	private Transform _target;
	[SerializeField] private float chaseDistance;
	public int Damage => _damage; 
	[SerializeField] private int _damage = 10;

	public Collider collider => _collider; 
	private Collider _collider;

	public Rigidbody rigidBody => _rigidBody; 
	private Rigidbody _rigidBody;

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

    [SerializeField]private Animate animator;
	
	public void Start()
	{
		_chasing = false;
		_rigidBody = GetComponent<Rigidbody>(); 
		_collider = GetComponent<Collider>();
		_navMeshAgent = GetComponent<NavMeshAgent>();
		_navMeshAgent.enabled = false;
		_target = GameObject.Find("Character").gameObject.transform;
		_collider.isTrigger = true; 
		_rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
		
	}
	

	protected void Chase()
	{
		_chasing = true;
		animator.Chase();
		_navMeshAgent.enabled = true;
		print("start chasing");

	}
	protected void StopChasing()
	{
		print("stop chasing");
		_chasing = false;
		animator.StopChasing();
		_navMeshAgent.enabled = false;

	}

	protected void Update()
	{
		var distance = Vector3.Distance(_target.position, transform.position);
		if (!_chasing)
		{
			if (distance < chaseDistance)
				Chase();
			return;
		}

		if (Vector3.Distance(_target.position, transform.position) > chaseDistance)
		{
			StopChasing();
			return;
		}
			
		_navMeshAgent.SetDestination(_target.position);
	}
}
