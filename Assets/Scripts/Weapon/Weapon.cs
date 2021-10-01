using System;
using System.Collections;
using Enemy;
using UnityEngine;

namespace Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected float Damage = 30f;
        [SerializeField] protected float AttackCooldown = 0.5f;
        private float _nextAttackTime;
        private const float WEAPON_SWITCH_ATTACK_COOLDOWN = 0.5f;

        private void UpdateNextAttackTime()
        {
            _nextAttackTime = Time.time + AttackCooldown;
        }

        private bool AttackCooldownPassed() => Time.time > _nextAttackTime;

        private void OnEnable()
        {
            _nextAttackTime = Time.time + WEAPON_SWITCH_ATTACK_COOLDOWN;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && AttackCooldownPassed())
            {
                Attack();
                UpdateNextAttackTime();
            }
        }

        protected abstract void Attack();
    }
}
