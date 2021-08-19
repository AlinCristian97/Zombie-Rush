using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private Camera _fpsCamera;
    [SerializeField] private float _zoomedOutFOV = 60f;
    [SerializeField] private float _zoomedInFOV = 20f;

    private bool _zoomedInToggle;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (_zoomedInToggle == false)
            {
                _zoomedInToggle = true;
                _fpsCamera.fieldOfView = _zoomedInFOV;
            }
            else
            {
                _zoomedInToggle = false;
                _fpsCamera.fieldOfView = _zoomedOutFOV;
            }
        }
    }
}
