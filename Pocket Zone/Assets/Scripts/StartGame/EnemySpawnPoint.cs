using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    private GameObject[] _spawnPoints;
    private GameObject[] _enemy;

    private void Awake()
    {
        _spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        _enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        foreach (GameObject enemy in _enemy)
        {
            GameObject spawn = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            enemy.transform.position = spawn.transform.position;
        }
    }
}