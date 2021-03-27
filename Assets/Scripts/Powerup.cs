using System;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public static event Action PowerUpPicked = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        PowerUpPicked();
        Destroy(gameObject);
    }
}
