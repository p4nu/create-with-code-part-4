using UnityEngine;

public class SnapToPlayer : MonoBehaviour
{
    private Transform _playerTransform;
    private Vector3 _offset;

    private void Awake()
    {
        _playerTransform = FindObjectOfType<PlayerController>().transform;
    }

    private void Start()
    {
        _offset = transform.position - _playerTransform.position;
    }

    private void LateUpdate()
    {
        transform.position = _playerTransform.position + _offset;
    }
}
