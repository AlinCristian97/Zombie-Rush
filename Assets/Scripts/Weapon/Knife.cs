using System;
using System.Collections;
using Enemy;
using UnityEngine;

namespace Weapon
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Animator))]
    public class Knife : Weapon
    {
        private Animator _animator;
        private Collider _collider;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _collider = GetComponent<Collider>();
            
            DeactivateCollider();
        }

        protected override void Attack()
        {
            _animator.SetTrigger("Attack");
        }

        #region Animator Trigger Functions

        private void ActivateCollider()
        {
            _collider.enabled = true;
        }

        private void DeactivateCollider()
        {
            _collider.enabled = false;
        }

        #endregion
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Health>().TakeDamage(Damage);
            }
        }
    }
}