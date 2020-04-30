using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float _restoreAngle = 90f;
    [SerializeField] float _addIntensity = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(_restoreAngle);
            other.GetComponentInChildren<FlashLightSystem>().AddLightIntensity(_addIntensity);
            Destroy(gameObject);
        }
    }


}
