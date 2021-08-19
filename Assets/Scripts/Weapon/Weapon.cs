using System.Collections;
using UnityEngine;

namespace Weapon
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Camera _fPCamera;
        [SerializeField] private float _range = 100f;
        [SerializeField] private float _damage = 30f;
        [SerializeField] private float _timeBetweenShots = 0.5f;
        [SerializeField] private ParticleSystem _muzzleFlash;
        [SerializeField] private GameObject _hitEffect;
        [SerializeField] private Ammo _ammoSlot;

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

        private IEnumerator Shoot()
        {
            _canShoot = false;
        
            // if (_ammoSlot.GetCurrentAmmo() > 0)
            // {
            //     PlayMuzzleFlash();
            //     ProcessRaycast();
            //     _ammoSlot.ReduceCurrentAmmo();
            // }

            yield return new WaitForSeconds(_timeBetweenShots);
            _canShoot = true;
        }

        private void PlayMuzzleFlash()
        {
            _muzzleFlash.Play();
        }

        private void ProcessRaycast()
        {
            if (Physics.Raycast(_fPCamera.transform.position, _fPCamera.transform.forward, out RaycastHit hit, _range))
            {
                CreateHitImpact(hit);
                var target = hit.transform.GetComponent<EnemyHealth>();
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
