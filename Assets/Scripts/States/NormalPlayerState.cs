using System;
using Interfaces;
using UnityEngine;

namespace States
{
    public class NormalPlayerState : IStateable
    {
        public static event Action PowerUpEnded = delegate { };
        
        public NormalPlayerState()
        {
            PowerUpEnded();
        }
        
        public void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Collided in " + this + " with " + other.gameObject.name);
            }
        }
    }
}
