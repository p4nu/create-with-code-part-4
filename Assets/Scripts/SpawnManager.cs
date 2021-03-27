using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    // ReSharper disable once RedundantDefaultMemberInitializer
    [SerializeField] private GameObject enemyPrefab = null;

    private const float SpawnRange = 8f;

    private void Start()
    {
        Instantiate(enemyPrefab, GenerateRandomPosition(), Quaternion.identity);
    }

    private Vector3 GenerateRandomPosition()
    {
        var randomXPosition = Random.Range(-SpawnRange, SpawnRange);
        var randomZPosition = Random.Range(-SpawnRange, SpawnRange);
        
        return new Vector3(randomXPosition, 0, randomZPosition);
    }
}