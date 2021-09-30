using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _chaseRange = 5f;
    [SerializeField] float _turnSpeed = 5f;

    private bool _isProvoked;
    private EnemyHealth _health;

    private NavMeshAgent _navMeshAgent;
    private float _distanceToTarget = Mathf.Infinity;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _health = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        if (_health.IsDead())
        {
            enabled = false;
            _navMeshAgent.enabled = false;
            _isProvoked = false;
        }
        
        _distanceToTarget = Vector3.Distance(_target.position, transform.position);

        if (_isProvoked)
        {
            EngageTarget();
        }
        else if (_distanceToTarget <= _chaseRange)
        {
            _isProvoked = true;
        }
    }
    
    public void OnDamageTaken()
    {
        _isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();

        if (_distanceToTarget >= _navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (_distanceToTarget <= _navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        _navMeshAgent.SetDestination(_target.position);
    }
    
    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);
    }
    
    private void FaceTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _chaseRange);
    }
}
