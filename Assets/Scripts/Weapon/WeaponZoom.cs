using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private RigidbodyFirstPersonController _fpsController;
    [SerializeField] private float _zoomedOutFOV = 60f;
    [SerializeField] private float _zoomedInFOV = 20f;
    [SerializeField] private float _zoomOutSensitivity = 2f;
    [SerializeField] private float _zoomInSensitivity = .5f;
    
    private bool _zoomedInToggle;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (_zoomedInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void OnDisable()
    {
        ZoomOut();
    }

    private void ZoomOut()
    {
        _zoomedInToggle = false;
        _camera.fieldOfView = _zoomedOutFOV;
        _fpsController.mouseLook.XSensitivity = _zoomOutSensitivity;
        _fpsController.mouseLook.YSensitivity = _zoomOutSensitivity;
    }

    private void ZoomIn()
    {
        _zoomedInToggle = true;
        _camera.fieldOfView = _zoomedInFOV;
        _fpsController.mouseLook.XSensitivity = _zoomInSensitivity;
        _fpsController.mouseLook.YSensitivity = _zoomInSensitivity;
    }
}
