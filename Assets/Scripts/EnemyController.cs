using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D enemy;
    SpriteRenderer spriteRenderer;

    [SerializeField] float enemySpeed = 1.0f;
    [SerializeField] bool movesVertically;

    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (movesVertically)
        {
            enemy.velocity = new Vector2(enemy.velocity.x, enemySpeed);
        }
        else
        {
            enemy.velocity = new Vector2(enemySpeed, enemy.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Walls")
        {
            enemySpeed = enemySpeed * (-1); //changes movement direction
            spriteRenderer.flipX = !spriteRenderer.flipX; //do the opposite
        }
    }


    void Update()
    {

    }

}
