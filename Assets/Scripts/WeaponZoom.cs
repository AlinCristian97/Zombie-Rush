using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private Camera _fpsCamera;
    [SerializeField] private float _zoomedOutFOV = 60f;
    [SerializeField] private float _zoomedInFOV = 20f;
    [SerializeField] private float _zoomOutSensitivity = 2f;
    [SerializeField] private float _zoomInSensitivity = .5f;

    private RigidbodyFirstPersonController _fpsController;

    private bool _zoomedInToggle;
    
    private void Start()
    {
        _fpsController = GetComponent<RigidbodyFirstPersonController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (_zoomedInToggle == false)
            {
                _zoomedInToggle = true;
                _fpsCamera.fieldOfView = _zoomedInFOV;
                _fpsController.mouseLook.XSensitivity = _zoomInSensitivity;
                _fpsController.mouseLook.YSensitivity = _zoomInSensitivity;
            }
            else
            {
                _zoomedInToggle = false;
                _fpsCamera.fieldOfView = _zoomedOutFOV;
                _fpsController.mouseLook.XSensitivity = _zoomOutSensitivity;
                _fpsController.mouseLook.YSensitivity = _zoomOutSensitivity;
            }
        }
    }
}
