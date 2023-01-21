using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public float timeLeft = 14f;

    void Update()
    {
        timeLeft -= 1 * Time.deltaTime;
        if (timeLeft == 0)
        {
            GameQuit();
            timeLeft = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
