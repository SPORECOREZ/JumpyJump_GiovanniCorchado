using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] Text countdownTimer;
    
    public float timer;

    private bool gameEnd = false;
    
    public AudioSource audioSource;

    public AudioClip gameBegin;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        timer = 2;
        countdownTimer.color = Color.magenta;
        audioSource.PlayOneShot(gameBegin);
    }

    void Update()
    {
        countdownTimer.enabled = true;
        timer -= Time.deltaTime;
        countdownTimer.text = timer.ToString ("0");

        if (timer <= 0 && gameEnd == false)
        {
            timer -= Time.deltaTime;
            timer = 10;
        }
        if (timer == 10)
        {
            countdownTimer.color = Color.blue;
        }
    }
}
