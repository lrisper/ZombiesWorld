using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera _fpsCamera;
    [SerializeField] float _range = 100f;
    [SerializeField] float _damage = 30f;

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
        if (Physics.Raycast(_fpsCamera.transform.position, _fpsCamera.transform.forward, out hit, _range))
        {
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
}
