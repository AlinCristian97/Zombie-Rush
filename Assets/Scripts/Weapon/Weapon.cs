using System;
using System.Collections;
using Enemy;
using UnityEngine;
using Weapon.Projectile;

namespace Weapon
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _range = 100f;
        [SerializeField] private float _damage = 30f;
        [SerializeField] private float _timeBetweenShots = 0.5f;
        [SerializeField] private ParticleSystem _muzzleFlash;
        [SerializeField] private GameObject _hitEffect;

        private bool _canShoot = true;

        private void OnEnable()
        {
            _canShoot = true;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && _canShoot)
            {
                StartCoroutine(Shoot());
            }
        }

        IEnumerator Shoot()
        {
            var projectileContainer = GetComponentInChildren<ProjectileContainer>();

            if (projectileContainer.HasProjectiles)
            {
                _canShoot = false;
                PlayMuzzleFlash();
                ProcessRaycast();
                projectileContainer.DecreaseProjectilesAmount();
                yield return new WaitForSeconds(_timeBetweenShots);
                _canShoot = true;
            }
        }

        private void PlayMuzzleFlash()
        {
            _muzzleFlash.Play();
        }

        private void ProcessRaycast()
        {
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit, _range))
            {
                CreateHitImpact(hit);
                var target = hit.transform.GetComponent<Health>();
                if (target == null) return;
                target.TakeDamage(_damage);
            }
        }

        private void CreateHitImpact(RaycastHit hit)
        {
            GameObject imapct = Instantiate(_hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        
            Destroy(imapct, 0.1f);
        }
    }
}
