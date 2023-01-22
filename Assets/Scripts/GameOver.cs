using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GameQuit());
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
            Debug.Log("Escape");
        }
    }

    IEnumerator GameQuit()
    {
        yield return new WaitForSeconds(14);
        Application.Quit();
        Debug.Log("Quit");
    }
}
