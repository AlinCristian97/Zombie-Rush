using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera _fPCamera;
    [SerializeField] float _range = 100f;
    [SerializeField] float _damage = 30f;
    [SerializeField] private ParticleSystem _muzzleFlash;

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
        RaycastHit hit;
        if (Physics.Raycast(_fPCamera.transform.position, _fPCamera.transform.forward, out hit, _range))
        {
            Debug.Log("I hit this thing: " + hit.transform.name);
            // TODO: add some hit effect for visual players
            var target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(_damage);
        }
    }
}
