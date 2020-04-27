using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{

    [SerializeField] Camera _fpsCamera;
    [SerializeField] float _zoomedOutFOV = 60f;
    [SerializeField] float _zoomedInFOV = 20f;

    bool _zoomedInToggled = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (_zoomedInToggled == false)
            {
                _zoomedInToggled = true;
                _fpsCamera.fieldOfView = _zoomedInFOV;
            }
            else
            {
                _zoomedInToggled = false;
                _fpsCamera.fieldOfView = _zoomedOutFOV;
            }
        }
    }
}
