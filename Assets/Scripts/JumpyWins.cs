using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpyWins : MonoBehaviour
{
    public AudioSource winAudio;

    public AudioClip winSound;

    public GameObject checkJumpy;

    void Start()
    {
        winAudio = GetComponent<AudioSource>();

        StartCoroutine("PlayWinSound");
    }

    void Update()
    {
        if (checkJumpy == null)
        {
            StopCoroutine("PlayWinSound");
        }
    }

    private IEnumerator PlayWinSound()
    {
        while (true)
        {
            yield return new WaitForSeconds(12);
            CancelInvoke("stopMusic");
            winAudio.PlayOneShot(winSound);
        }
    }
}
