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

    private Animator _animator;
	
	public void Start()
	{
		_chasing = false;
		_rigidBody = GetComponent<Rigidbody>(); 
		_collider = GetComponent<Collider>();
		_animator = GetComponent<Animator>();
		_navMeshAgent = GetComponent<NavMeshAgent>();
		_navMeshAgent.enabled = true;
		_target = GameObject.Find("Character").gameObject.transform;
		_collider.isTrigger = true; 
		_rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
		
	}
	

	protected void Chase()
	{
		_chasing = true;
		_animator.SetBool("IsChasing", _chasing);
		
		
	}
	protected void StopChasing()
	{
		_chasing = false;
		_animator.SetBool("IsChasing", _chasing);
		
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
			StopChasing();
		_navMeshAgent.SetDestination(_target.position);
	}
}
