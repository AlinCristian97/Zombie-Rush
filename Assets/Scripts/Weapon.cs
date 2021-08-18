using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera _fPCamera;
    [SerializeField] float _range = 100f;
    [SerializeField] float _damage = 30f;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private GameObject _hitEffect;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
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
