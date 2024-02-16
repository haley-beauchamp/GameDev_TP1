using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpForce;

    private Rigidbody2D player;
    private SpriteRenderer spriteRenderer;

    bool isFacingRight;
    bool isOnGround;

    void Start()
    {
        isFacingRight = false;
        player = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");

        player.velocity = new Vector2(horizontal * movementSpeed, player.velocity.y);

        if (Input.GetKey(KeyCode.Space) && isOnGround) //only let the player jump when on the ground
        {
            Jump();
        }

        if (horizontal > 0)
        {
            isFacingRight = false;
        }
        else if (horizontal < 0)
        {
            isFacingRight = true;
        }

        spriteRenderer.flipX = isFacingRight;
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