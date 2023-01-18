using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpyController : MonoBehaviour
{
    public float jumpSpeed = 4f;

    private bool doubleJump;

    private Animator animator;

    [SerializeField] private Rigidbody2D jumpy;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        jumpy = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        if(Input.GetButtonDown("Jump"))
        {
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
}
