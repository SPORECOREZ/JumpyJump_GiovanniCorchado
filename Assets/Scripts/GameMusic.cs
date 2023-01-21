using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    public AudioSource gameMusicAudio;

    public GameObject checkJumpy;

    void Start()
    {
        gameMusicAudio = GetComponent<AudioSource>();

        Invoke("playMusic", 2.0f);
        Invoke("stopMusic", 12.0f);
    }

    void Update()
    {
        if (!GameObject.FindWithTag("Player"))
        {
            gameMusicAudio.Stop();
        }
    }

    void playMusic()
    {
        gameMusicAudio.Play();
    }

    void stopMusic()
    {
        gameMusicAudio.Stop();
    }
}
