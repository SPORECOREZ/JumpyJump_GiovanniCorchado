using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    public Transform target;
    public float sawSpeed = 5f;

    public AudioSource audioSource;

    public AudioClip loseSound;
    public AudioClip jumpyDies;
    
    private Rigidbody2D saw;
    
    void Start()
    {
        saw = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float step = sawSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(loseSound);
            audioSource.PlayOneShot(jumpyDies);
        }
    }
}
