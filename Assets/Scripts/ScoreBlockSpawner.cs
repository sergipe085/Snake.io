using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScoreBlockSpawner : MonoBehaviour
{
    [SerializeField] private ScoreBlock scoreBlockPrefab;

    private float timer = 0.0f;
    private float spawnTime = 5.0f;

    private void Start() {
        Spawn();
    }

    private void Update() {
        timer += Time.deltaTime;
        if (timer > spawnTime) {
            Spawn();
        }
    }

    private void Spawn() {
        Instantiate(scoreBlockPrefab, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f), Quaternion.identity);
        spawnTime = Random.Range(2f, 5f);
        timer = 0.0f;
    }
}
