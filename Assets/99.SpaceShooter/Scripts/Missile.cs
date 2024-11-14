using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 10f;
    public GameObject blastEffect;
    private void Update()
    {
        transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Wall"))
        {
            Destroy(base.gameObject);
        }
        if (other.CompareTag("Meteor"))
        {
            Instantiate(blastEffect,transform.position,Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(base.gameObject);
        }
    }

}
