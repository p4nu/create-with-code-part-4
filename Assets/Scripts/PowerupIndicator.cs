using States;
using UnityEngine;

public class PowerupIndicator : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    private void OnEnable()
    {
        Powerup.PowerUpPicked += OnPowerUpPicked;
        NormalPlayerState.PowerUpEnded += OnPowerUpEnded;
    }

    private void OnDisable()
    {
        Powerup.PowerUpPicked -= OnPowerUpPicked;
        NormalPlayerState.PowerUpEnded -= OnPowerUpEnded;
    }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnPowerUpPicked()
    {
        _meshRenderer.enabled = true;
    }

    private void OnPowerUpEnded()
    {
        _meshRenderer.enabled = false;
    }
}
