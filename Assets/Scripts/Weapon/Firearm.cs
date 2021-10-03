using System.Collections;
using Enemy;
using UnityEngine;
using Weapon.Projectile;

namespace Weapon
{
    public class Firearm : Weapon
    {
        [SerializeField] private float _range = 100f;

        [SerializeField] private Camera _camera;
        [SerializeField] private ParticleSystem _muzzleFlash;
        [SerializeField] private GameObject _hitEffect;

        protected override void Attack()
        {
            var projectileContainer = GetComponentInChildren<ProjectileContainer>();

            if (projectileContainer.HasProjectiles)
            {
                Animator.SetTrigger("Attack");
                PlayMuzzleFlash();
                ProcessRaycast();
                projectileContainer.DecreaseProjectilesAmount();
            }
        }
        
        private void ProcessRaycast()
        {
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit, _range))
            {
                CreateHitImpact(hit);
                var target = hit.transform.GetComponent<Health>();
                if (target == null) return;
                target.TakeDamage(Damage);
            }
        }

        private void CreateHitImpact(RaycastHit hit)
        {
            GameObject impact = Instantiate(_hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        
            Destroy(impact, 0.1f);
        }
        
        private void PlayMuzzleFlash()
        {
            _muzzleFlash.Play();
        }
    }
}