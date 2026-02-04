using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private float minY = -1f;
    [SerializeField] private float maxY = 1.5f;

    private bool isSpawning = true;

    void Start()
    {
        InvokeRepeating(nameof(SpawnPipe), 0f, spawnInterval);
        Player.OnPlayerDied += StopSpawning;
    }

    void OnDestroy()
    {
        Player.OnPlayerDied -= StopSpawning;
    }

    private void SpawnPipe()
    {
        if (!isSpawning) return;

        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(transform.position.x, randomY, 0);

        Instantiate(pipePrefab, spawnPos, Quaternion.identity);
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }
}
