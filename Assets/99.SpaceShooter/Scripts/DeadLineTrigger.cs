using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLineTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Meteor"))
        { 
            Destroy(other.gameObject);
        }
    }
}
