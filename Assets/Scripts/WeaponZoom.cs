﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{

    [SerializeField] Camera _fpsCamera;
    [SerializeField] RigidbodyFirstPersonController _fpsController;
    [SerializeField] float _zoomedOutFOV = 60f;
    [SerializeField] float _zoomedInFOV = 20f;

    [SerializeField] float _zoomedOutSensitivity = 2f;
    [SerializeField] float _zoomedInSensitivity = .5f;


    bool _zoomedInToggled = false;

    private void OnDisable()
    {
        ZoomOut();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (_zoomedInToggled == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomIn()
    {
        _zoomedInToggled = true;
        _fpsCamera.fieldOfView = _zoomedInFOV;
        _fpsController.mouseLook.XSensitivity = _zoomedInSensitivity;
        _fpsController.mouseLook.YSensitivity = _zoomedInSensitivity;
    }

    private void ZoomOut()
    {
        _zoomedInToggled = false;
        _fpsCamera.fieldOfView = _zoomedOutFOV;
        _fpsController.mouseLook.XSensitivity = _zoomedOutSensitivity;
        _fpsController.mouseLook.YSensitivity = _zoomedOutSensitivity;
    }


}
