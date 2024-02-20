using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    [Header("PlayerJump")]
    private bool canDoubleJump;
    public float jumpForce;
    public float bounceForce;

    [Header("Components")]
    public Rigidbody2D rigidBody;

    [Header("Grounded")]
    public Transform groundCheckpoint;

    [Header("Animator")]
    public Animator anim;
    private SpriteRenderer spriteRend;

    public LayerMask whatIsGround;

    private bool isGrounded;

    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    public bool stopInput;

    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (!PauseMenu.instance.isPaused && !stopInput)
        {
            if (knockBackCounter <= 0)
            {
                rigidBody.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), rigidBody.velocity.y);

                isGrounded = Physics2D.OverlapCircle(groundCheckpoint.position, .2f, whatIsGround);

                if (isGrounded)
                {
                    canDoubleJump = true;
                }

                if (Input.GetButtonDown("Jump"))
                {
                    if (isGrounded)
                    {
                        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
                        AudioManager.instance.PlaySFX(10);
                    }
                    else
                    {
                        if (canDoubleJump)
                        {
                            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
                            AudioManager.instance.PlaySFX(10);
                            canDoubleJump = false;
                        }
                    }
                }

                if (rigidBody.velocity.x < 0)
                {
                    spriteRend.flipX = true;
                }
                else if (rigidBody.velocity.x > 0)
                {
                    spriteRend.flipX = false;
                }
            }
            else
            {
                knockBackCounter -= Time.deltaTime;

                if (!spriteRend.flipX)
                {
                    rigidBody.velocity = new Vector2(-knockBackForce, rigidBody.velocity.y);

                }
                else
                {
                    rigidBody.velocity = new Vector2(knockBackForce, rigidBody.velocity.y);
                }
            }
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(rigidBody.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }

    public void KnockBack()
    {
        knockBackCounter = knockBackLength;
        rigidBody.velocity = new Vector2(0f, knockBackForce);
    }

    public void Bounce()
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, bounceForce);
    }
}
