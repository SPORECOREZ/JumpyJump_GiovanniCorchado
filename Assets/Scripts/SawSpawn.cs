using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSpawn : MonoBehaviour
{
    public GameObject sawPrefab;
    public float startTime = 0f;

    void Start()
    {
        sawPrefab.gameObject.SetActive(false);
    }

    void Update()
    {
        startTime += Time.deltaTime;
        if (startTime >= 3)
        {
            sawPrefab.gameObject.SetActive(true);
        }
    }
}
