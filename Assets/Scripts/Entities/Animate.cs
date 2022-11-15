using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    [SerializeField]private Animator _animator;
    public void Chase()
    {
        _animator.SetBool("IsChasing", true);
    }
    public void StopChasing()
    {
        _animator.SetBool("IsChasing", false);
    }
}
