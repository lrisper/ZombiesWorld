using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float _lightDecay = .1f;
    [SerializeField] float _angleDecay = 1f;
    [SerializeField] float _minAngle = 40f;

    Light _myLight;

    private void Start()
    {
        _myLight = GetComponent<Light>();

    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();

    }

    private void DecreaseLightAngle()
    {
        if (_myLight.spotAngle <= _minAngle)
        {
            return;
        }
        else
        {
            _myLight.spotAngle -= _minAngle * Time.deltaTime;
        }

    }

    private void DecreaseLightIntensity()
    {
        _myLight.intensity -= _lightDecay * Time.deltaTime;
    }
}
