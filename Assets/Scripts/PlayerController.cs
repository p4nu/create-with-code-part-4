using System.Collections;
using Interfaces;
using States;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 300f;
    [SerializeField] private float powerUpStrength = 15f;

    private float _verticalInput;
    private Rigidbody _rigidbodyPlayer;
    private Transform _focalPointTransform;
    private IStateable _currentState;

    private void Normalize()
    {
        _currentState = new NormalPlayerState();
    }

    private void Awake()
    {
        _rigidbodyPlayer = GetComponent<Rigidbody>();
        _focalPointTransform = FindObjectOfType<RotateCamera>().transform;
        
        Normalize();
    }

    private void OnEnable()
    {
        Powerup.PowerUpPicked += OnPowerUpPicked;
    }

    private void OnDisable()
    {
        Powerup.PowerUpPicked -= OnPowerUpPicked;
    }

    private void OnPowerUpPicked()
    {
        _currentState = new PoweredUpPlayerState(this, powerUpStrength);
        
        StartCoroutine(PowerUpCountdownRoutine());
    }

    private void Update()
    {
        _verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        _rigidbodyPlayer.AddForce(
            _verticalInput
            * speed
            * Time.deltaTime
            * _focalPointTransform.forward
            );
    }

    private void OnCollisionEnter(Collision other)
    {
        _currentState.OnCollisionEnter(other);
    }
    
    private IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7f);
        
        Normalize();
    }
}
