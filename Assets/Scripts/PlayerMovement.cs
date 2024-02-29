using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpForce;

    private Rigidbody2D player;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    bool isFacingRight;
    bool isOnGround;

    void Start()
    {
        isFacingRight = true;
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        int animState = 0;

        player.velocity = new Vector2(horizontal * movementSpeed, player.velocity.y);

        if (Input.GetKey(KeyCode.Space) && isOnGround) //only let the player jump when on the ground
        {
            Jump();
        }

        if (horizontal != 0)
        {
            animState = 2;

            if (horizontal > 0)
            {
                isFacingRight = true;
            }
            else if (horizontal < 0)
            {
                isFacingRight = false;
            }
        }

        if (player.velocity.y < -1) //if the player is falling (< -1 because 0 was producing animation issues)
        {
            isOnGround = false;
        }

        spriteRenderer.flipX = isFacingRight;
        animator.SetInteger("AnimState", animState);
        animator.SetBool("Grounded", isOnGround);
    }

    void Jump()
    {
        player.velocity = new Vector2(player.velocity.x, jumpForce);
        isOnGround = false; //prevent infinite floating by noting that the player is no longer grounded
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }
}