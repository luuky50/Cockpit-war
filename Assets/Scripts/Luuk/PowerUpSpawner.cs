using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject powerUpPreFab;

    [SerializeField]
    private BoxCollider2D spawnArea;
    [SerializeField]
    private int spawnRate = 5;


    private void Start()
    {
        StartCoroutine(SpawnPowerups());
    }

    IEnumerator SpawnPowerups()
    {
        while (true)
        {
            Vector2 newPos = new Vector2(Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x), Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y));
            Instantiate(powerUpPreFab, newPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
    }

}
