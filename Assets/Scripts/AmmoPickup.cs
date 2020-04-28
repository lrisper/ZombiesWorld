using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int _ammoAmont = 5;
    [SerializeField] AmmoType _ammoType;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(_ammoType, _ammoAmont);
            Destroy(gameObject);
        }
    }
}
