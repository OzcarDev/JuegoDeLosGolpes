using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public Transform[] spawnPositions;

    public GameObject enemyPrefab;

    private int _enemyFinder;

    private int _enemyCount;

    private int _wave;

    private int _maxWave;
    private bool _ableSpawn;
    private int _positionIndex;

    private void Start()
    {
        EnemySpawner(_enemyCount);
        _ableSpawn = true;
    }

    private void Update()
    {
        _enemyFinder = FindObjectsOfType<AIController>().Length;
        if (_enemyFinder == 0 && _ableSpawn == true)
        {
            _enemyCount += 3;
            EnemySpawner(_enemyCount);
        }
    }

    private void EnemySpawner(int actualenemys)
    {
        for (int i = 0; i < actualenemys; i++)
        {
            _positionIndex = Random.Range(0,3);
            Instantiate(enemyPrefab, spawnPositions[_positionIndex].transform.position,spawnPositions[_positionIndex].transform.rotation);
        }
    }
}