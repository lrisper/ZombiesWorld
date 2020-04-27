using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlot;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int AmmoAmount;
    }

    //public int GetCurrentAmmo()
    //{
    //    //return AmmoAmount;
    //}

    public void ReduceCurrentAmmo()
    {
        //_ammoAmount--;
    }
}
