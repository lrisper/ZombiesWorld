using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int _curentWeapon = 0;

    void Start()
    {
        SetWeaponActive();
    }

    void Update()
    {
        int previousWeapon = _curentWeapon;
        ProcessKeyInput();
        ProcessScroolWheel();
        if (previousWeapon != _curentWeapon)
        {
            SetWeaponActive();
        }
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            _curentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            _curentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            _curentWeapon = 2;
        }
    }

    // scrool up
    private void ProcessScroolWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (_curentWeapon >= transform.childCount - 1)
            {
                _curentWeapon = 0;
            }
            else
            {
                _curentWeapon++;
            }
        }

        // scrool down
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (_curentWeapon <= 0)
            {
                _curentWeapon = transform.childCount - 1;
            }
            else
            {
                _curentWeapon--;
            }
        }
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;
        foreach (Transform weapon in transform)
        {
            if (weaponIndex == _curentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }


}
