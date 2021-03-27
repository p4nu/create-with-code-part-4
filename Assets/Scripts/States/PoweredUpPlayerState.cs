using Interfaces;
using UnityEngine;

namespace States
{
    public class PoweredUpPlayerState : IStateable
    {
        private readonly PlayerController _player;
        private readonly float _powerUpStrength;
        
        public PoweredUpPlayerState(PlayerController player, float powerUpStrength)
        {
            _player = player;
            _powerUpStrength = powerUpStrength;
        }
        
        public void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Enemy")) return;
            
            Debug.Log("Collided in " + this + " with " + other.gameObject.name);

            var enemyGameObject = other.gameObject;
            var enemyRb = enemyGameObject.GetComponent<Rigidbody>();

            var awayFromPlayer = enemyGameObject.transform.position -
                                 _player.transform.position;
            
            enemyRb.AddForce(awayFromPlayer * _powerUpStrength, ForceMode.Impulse);
        }
    }
}
