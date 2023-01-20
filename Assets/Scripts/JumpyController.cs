using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JumpyController : MonoBehaviour
{
    public float timer = 0f;
    public float timeLeft = 14f;
    float jumpSpeed = 12f;

    public static int jumpyHealth;

    public GameObject gameStart;
    public GameObject spacebar;
    public GameObject gameLose;
    public GameObject gameWin;
    public GameObject jumpyLives;
    public GameObject jumpyDeath;

    public AudioSource audioSource;

    public AudioClip gameBegin;
    public AudioClip gameMusic;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip jumpyDies;
    public AudioClip jumpyJump;

    //private bool musicToggle = false;

    [SerializeField] Text countdownTimer;

    public GameObject playBlood;

    private bool jumpyAlive = true;
    private bool doubleJump;

    private Animator animator;

    [SerializeField] private Rigidbody2D jumpy;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        jumpy = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        jumpyHealth = 1;

        gameLose.gameObject.SetActive(false);
        jumpyLives.gameObject.SetActive(true);
        jumpyDeath.gameObject.SetActive(false);
    }

    void Update()
    {
        timer += 1 * Time.deltaTime;
        if (timer <= 2)
        {
            gameStart.gameObject.SetActive(true);
            spacebar.gameObject.SetActive(true);
            jumpSpeed = 0f;
        }
        if (timer >= 2)
        {
            gameStart.gameObject.SetActive(false);
            spacebar.gameObject.SetActive(false);
            jumpSpeed = 12f;
        }
        if (timer > 12 && jumpyAlive == true)
        {
            audioSource.PlayOneShot(loseSound);
            gameWin.gameObject.SetActive(true);
            jumpSpeed = 0f;
        }
        if (timer < 12)
        {
            gameWin.gameObject.SetActive(false);
        }

        timeLeft -= 1 * Time.deltaTime;
        if (timeLeft <= 0)
        {
            GameOver();
            timeLeft = 0;
        }

        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        if(Input.GetButtonDown("Jump"))
        {
            audioSource.PlayOneShot(jumpyJump);

            if (IsGrounded() || doubleJump)
            {
                jumpy.velocity = new Vector2(jumpy.velocity.x, jumpSpeed);

                doubleJump = !doubleJump;
            }
        }

        if (Input.GetButtonUp("Jump") && jumpy.velocity.y > 0f)
        {
            jumpy.velocity = new Vector2(jumpy.velocity.x, jumpy.velocity.y * 0.5f);
        }

        if (jumpy.velocity.y == 0)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }

        if (jumpy.velocity.y > 0)
        {
            animator.SetBool("isJumping", true);
        }

        if (jumpy.velocity.y < 0)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void GameOver()
    {
        Application.Quit();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Saw"))
        {
            jumpyHealth = 0;
            jumpyAlive = false;
            gameLose.gameObject.SetActive(true);
            jumpyDeath.gameObject.SetActive(true);
            jumpyLives.gameObject.SetActive(false);
            Explode();
            Destroy(gameObject);
        }
    }

    void Explode()
    {
        GameObject blood = Instantiate(playBlood, new Vector2(-4, -3), Quaternion.identity);
        blood.GetComponent<ParticleSystem>().Play();
    }
}
