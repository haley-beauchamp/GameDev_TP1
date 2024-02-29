using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Rigidbody2D player;
    private Animator animator;

    private bool isAttacking;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            isAttacking = true;
        }

        animator.SetBool("Attack", isAttacking);
        isAttacking = false;
    }
}
