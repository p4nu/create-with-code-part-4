using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 300f;

    private Rigidbody _enemyRb;
    private Transform _playerTransform;
    private Vector3 _lookDirection;
    
    private void Awake()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _playerTransform = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        _lookDirection = (_playerTransform.position - transform.position).normalized;
    }

    private void FixedUpdate()
    {
        _enemyRb.AddForce(speed * Time.deltaTime * _lookDirection);
    }
}
