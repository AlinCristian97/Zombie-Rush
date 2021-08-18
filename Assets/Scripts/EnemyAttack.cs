using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _damage = 40f;
    
    private PlayerHealth _target;


    private void Start()
    {
        _target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (_target == null) return;
        _target.TakeDamage(_damage);
        Debug.Log("bang bang");
    }
}
