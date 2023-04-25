using System.Collections;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;

public sealed class AidKit : BonuseBase// : MonoBehaviour
{
    [SerializeField] private int _healValue;
    public void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.attachedRigidbody.GetComponent<PlayerHealth>();
        if (playerHealth)
        {
            if (playerHealth.GetHPvalue() < playerHealth.MaxHealth)
            {
                playerHealth.Heal(_healValue);

                DestroyAidKit();
            }
            else
            {
                Debug.LogWarning(" AidKit.Heal is max");
            }
        }
    }

    public void DestroyAidKit()
    {
        Destroy(gameObject, 0.1f);
    }
}
