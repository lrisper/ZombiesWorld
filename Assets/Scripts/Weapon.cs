﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera _fpsCamera;
    [SerializeField] float _range = 100f;
    [SerializeField] float _damage = 30f;
    [SerializeField] ParticleSystem _muzzleFlash;
    [SerializeField] GameObject _hitEffect;
    [SerializeField] float _destoryImpact = .1f;
    [SerializeField] Ammo _ammoSlot;
    [SerializeField] AmmoType _ammoType;
    [SerializeField] float _timeBetweenShoots = .5f;
    [SerializeField] TextMeshProUGUI _ammoText;

    bool _canShoot = true;

    public void OnEnable()
    {
        _canShoot = true;
    }

    void Update()
    {
        DisplayAmmo();
        if (Input.GetButtonDown("Fire1") && _canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    private void DisplayAmmo()
    {
        int currentAmmo = _ammoSlot.GetCurrentAmmo(_ammoType);
        _ammoText.text = currentAmmo.ToString();
    }

    private IEnumerator Shoot()
    {
        _canShoot = false;
        if (_ammoSlot.GetCurrentAmmo(_ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            _ammoSlot.ReduceCurrentAmmo(_ammoType);
        }
        yield return new WaitForSeconds(_timeBetweenShoots);
        _canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        _muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(_fpsCamera.transform.position, _fpsCamera.transform.forward, out hit, _range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null)
            {
                return;
            }
            target.TakeDamage(_damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(_hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, _destoryImpact);
    }
}
