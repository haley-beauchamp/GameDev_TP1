using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    private Rigidbody2D player;

    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] forwardSpriteList;
    [SerializeField] Sprite[] backwardSpriteList;
    [SerializeField] Sprite[] sideSpriteList;
    [SerializeField] float spriteChangeInterval = 0.5f;

    Sprite[] desiredSpriteList;
    bool isFacingRight;
    bool isFacingBack;

    private float timer;
    private int currentSprite = 0;

    void Start()
    {
        desiredSpriteList = forwardSpriteList;
        timer = spriteChangeInterval;
        isFacingBack = false;
        isFacingRight = false;

        player = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        if (horizontal > 0)
            isFacingRight = true;
        else
        {
            isFacingRight = false;
        }

        if (vertical > 0)
            isFacingBack = true;
        else
        {
            isFacingBack = false;
        }

        if (horizontal != 0 | vertical != 0)
        {
            if (horizontal != 0)
            {
                desiredSpriteList = sideSpriteList;
                spriteRenderer.flipX = isFacingRight;
            } else if (vertical != 0 && isFacingBack)
            {
                desiredSpriteList = backwardSpriteList;
            } else
            {
                desiredSpriteList = forwardSpriteList;
            }

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                ChangeSprite(desiredSpriteList);
                timer = spriteChangeInterval;
            }
        } else
        {
            spriteRenderer.sprite = desiredSpriteList[0];
        }

        player.velocity = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);
    }

    private void ChangeSprite(Sprite[] desiredSpriteList)
    {
        currentSprite = (currentSprite + 1) % desiredSpriteList.Length;
        spriteRenderer.sprite = desiredSpriteList[currentSprite];
    }
}