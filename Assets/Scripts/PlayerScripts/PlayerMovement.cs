using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] GameObject interactionAvailable;

    private Rigidbody2D player;
    private Animator animator;

    bool isFacingRight;
    public static bool isOnGround;
    public static bool playerDead = false;
    private float horizontal;

    void Start()
    {
        isFacingRight = true;
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!playerDead)
        {
            horizontal = Input.GetAxis("Horizontal");
            int animState = 0;

            player.velocity = new Vector2(horizontal * movementSpeed, player.velocity.y);

            if (Input.GetKey(KeyCode.Space) && isOnGround)
            {
                Jump();
            }

            if (horizontal != 0)
            {
                animState = 2; //running animation

                if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
                {
                    Flip();
                }
            }
            animator.SetInteger("AnimState", animState);
            animator.SetBool("Grounded", isOnGround);
        }
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

    public void notifyPlayer()
    {
        interactionAvailable.SetActive(true);
    }

    public void denotifyPlayer()
    {
        interactionAvailable.SetActive(false);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
    }
}