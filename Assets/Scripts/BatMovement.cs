using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : EnemyMovement
{
    protected override void FixedUpdate()
    {
        Casting();

        if (isFollowingPlayer)
        {
            Vector2 targetPosition = player.transform.position + (player.GetComponent<Collider2D>().bounds.extents.y * Vector3.up);
            Vector2 direction = (targetPosition - (Vector2) transform.position).normalized;
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
}