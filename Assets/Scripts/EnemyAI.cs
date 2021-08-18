using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _chaseRange = 5f;
    
    private NavMeshAgent _navMeshAgent;
    private float _distanceToTarget = Mathf.Infinity;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _distanceToTarget = Vector3.Distance(_target.position, transform.position);

        if (_distanceToTarget <= _chaseRange)
        {
            _navMeshAgent.SetDestination(_target.position);
        }
    }
}
