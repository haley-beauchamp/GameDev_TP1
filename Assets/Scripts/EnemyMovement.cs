using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected float enemySpeed;
    [SerializeField] protected GameObject player;

    protected Rigidbody2D enemy;

    protected bool travellingLeft = false;
    protected bool isFollowingPlayer = false;

    float raycastDistance = 4;

    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        Casting();

        if (isFollowingPlayer)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            enemy.velocity = direction * enemySpeed;
        }
        else if (travellingLeft)
        {
            enemy.velocity = new Vector2(-enemySpeed, enemy.velocity.y);
        }
        else
        {
            enemy.velocity = new Vector2(enemySpeed, enemy.velocity.y);
        }
    }

    protected void Casting()
    {
        Debug.DrawRay(transform.position, Vector2.right * (raycastDistance + 1), Color.red);
        Debug.DrawRay(transform.position, Vector2.left * raycastDistance, Color.red);

        RaycastHit2D castRight = Physics2D.Raycast(transform.position, Vector2.right * (travellingLeft ? -1 : 1), raycastDistance + 1, LayerMask.GetMask("Walls", "Player"));
        RaycastHit2D castLeft = Physics2D.Raycast(transform.position, Vector2.left * (travellingLeft ? -1 : 1), raycastDistance, LayerMask.GetMask("Walls", "Player"));

        if (castRight.collider != null || castLeft.collider != null)
        {
            if (((castRight.collider != null) && castRight.collider.CompareTag("Player")) || ((castLeft.collider != null) && castLeft.collider.CompareTag("Player")))
            {
                isFollowingPlayer = true;
                Flip();
                return;
            }
            else if (((castRight.collider != null) && castRight.collider.CompareTag("Wall")) || ((castLeft.collider != null) && castLeft.collider.CompareTag("Wall")))
            {
                Flip();
            }
        }
        isFollowingPlayer = false;
    }

    public void Flip()
    {
        if (isFollowingPlayer && ((player.transform.position.x > enemy.position.x && !travellingLeft) ||
            (player.transform.position.x < enemy.position.x && travellingLeft)))
        {
            return;
        }
        else
        {
            travellingLeft = !travellingLeft;
            gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
    }
}