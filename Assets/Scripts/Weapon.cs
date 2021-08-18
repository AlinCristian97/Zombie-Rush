using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera _fPCamera;
    [SerializeField] float _range = 100f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        Physics.Raycast(_fPCamera.transform.position, _fPCamera.transform.forward, out hit, _range);
        Debug.Log("I hit this thing: " + hit.transform.name);
    }
}
