using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D _spawnBox;
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private int _enemiesPerWave;
    [SerializeField]
    private float _waveDuration;
    [SerializeField]
    private float _waveOffset;

    private bool _doSpawn;

    void Start() {
        InvokeRepeating("SpawnWave", _waveDuration, _waveDuration);
    }

    void SpawnEnemy(Vector3 position) {
        int randomIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[randomIndex], position, Quaternion.identity);
        //Debug.Log("spawning enemy at" + position);
    }

    void SpawnWave() {
        Vector3 center = _spawnBox.bounds.center;
        Vector3 extents = _spawnBox.bounds.extents;

        for(int i = 0; i < _enemiesPerWave; i++) {
            Vector3 spawnPos = new Vector3(
                center.x + Random.Range(-extents.x, extents.x),
                center.y + Random.Range(-extents.y, extents.y),
                center.z
            );
            SpawnEnemy(spawnPos);
        }

    }
}
