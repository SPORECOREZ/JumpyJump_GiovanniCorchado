using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSpawn : MonoBehaviour
{
    public GameObject sawPrefab;

    void Start()
    {
        StartCoroutine(SpawnSaw1());
        StartCoroutine(SpawnSaw2());
        StartCoroutine(SpawnSaw3());
        StartCoroutine(SpawnSaw4());
    }

    IEnumerator SpawnSaw1()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(sawPrefab, new Vector2(11,-3), Quaternion.identity);
    }

    IEnumerator SpawnSaw2()
    {
        yield return new WaitForSeconds(4f);
        Instantiate(sawPrefab, new Vector2(11, 1), Quaternion.identity);
    }

    IEnumerator SpawnSaw3()
    {
        yield return new WaitForSeconds(6f);
        Instantiate(sawPrefab, new Vector2(11,-3), Quaternion.identity);
    }

    IEnumerator SpawnSaw4()
    {
        yield return new WaitForSeconds(8f);
        Instantiate(sawPrefab, new Vector2(11, 1), Quaternion.identity);
    }
}
