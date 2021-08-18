using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _damage = 40f;

    private void Start()
    {
        
    }

    public void AttackHitEvent()
    {
        if (_target == null) return;
        
        Debug.Log("bang bang");
    }
}
