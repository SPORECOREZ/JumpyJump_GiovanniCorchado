using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject sawPrefab;

    [SerializeField] private float swarmerInterval = 3.5f;

    void Start()
    {
        StartCoroutine(spawnSaw(swarmerInterval, sawPrefab));
    }

    private IEnumerator spawnSaw(float interval, GameObject saw)
    {
        yield return new WaitForSeconds(interval);
        GameObject newSaw = Instantiate(saw, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnSaw(interval, saw));
    }
}
