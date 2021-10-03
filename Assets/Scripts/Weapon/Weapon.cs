using System;
using System.Collections;
using Enemy;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Weapon
{
    [RequireComponent(typeof(Animator))]
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected float Damage = 30f;
        [SerializeField] protected float AttackCooldown = 0.5f;
        private float _nextAttackTime;
        private const float WEAPON_SWITCH_ATTACK_COOLDOWN = 0.5f;
        protected Animator Animator;
        [SerializeField] private Rigidbody _playerRigidbody;

        private void UpdateNextAttackTime()
        {
            _nextAttackTime = Time.time + AttackCooldown;
        }

        private bool AttackCooldownPassed() => Time.time > _nextAttackTime;

        private void OnEnable()
        {
            Animator = GetComponent<Animator>();
            _nextAttackTime = Time.time + WEAPON_SWITCH_ATTACK_COOLDOWN;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && AttackCooldownPassed())
            {
                Attack();
                UpdateNextAttackTime();
            }
            
            HandleMoveAnimation();
        }

        private void HandleMoveAnimation()
        {
            var input = new Vector2
            {
                x = CrossPlatformInputManager.GetAxis("Horizontal"),
                y = CrossPlatformInputManager.GetAxis("Vertical")
            };
            
            if (input.x > 0 || input.x < 0 || input.y > 0 || input.y < 0)
            {
                Animator.SetBool("IsWalking", true);
                Animator.SetBool("IsIdling", false);
            }
            else
            {
                Animator.SetBool("IsWalking", false);
                Animator.SetBool("IsIdling", true);
            }
        }

        protected abstract void Attack();
    }
}
