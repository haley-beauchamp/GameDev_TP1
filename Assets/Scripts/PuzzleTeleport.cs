using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTeleport : MonoBehaviour
{
    [SerializeField] Transform spawnPosition;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = spawnPosition.position;
        }
    }
}
