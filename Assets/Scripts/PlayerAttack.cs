using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;

    private bool isAttacking = false;
    private GameObject attackArea = default;

    private float timeToAttack = 0.5f;
    private float timer = 0f;
    private float cooldownTimer = 0f;
    private float attackCooldown = 1.5f;

    void Start()
    {
        animator = GetComponent<Animator>();

        attackArea = transform.GetChild(1).gameObject;
    }

    void Update()
    {
        if (!PlayerMovement.playerDead && PlayerMovement.isOnGround)
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                if (!isAttacking && cooldownTimer == 0)
                {
                    Attack();
                }
            }

            if (isAttacking)
            {
                timer += Time.deltaTime;

                if (timer >= timeToAttack)
                {
                    timer = 0;
                    isAttacking = false;
                    attackArea.SetActive(isAttacking);
                    animator.SetBool("Attack", isAttacking);
                    cooldownTimer += Time.deltaTime;
                }
            } 
            else if (cooldownTimer != 0)
            {
                cooldownTimer += Time.deltaTime;
                if (cooldownTimer >= attackCooldown)
                {
                    cooldownTimer = 0;
                }
            }
        }
    }

    private void Attack()
    {
        isAttacking = true;
        attackArea.SetActive(isAttacking);
        animator.SetBool("Attack", isAttacking);
    }
}