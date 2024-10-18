using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("°¨Áö");
            player.GetComponent<Rigidbody2D>().AddForceAtPosition(Vector2.zero * 500f, player.transform.position);
        }
    }

}