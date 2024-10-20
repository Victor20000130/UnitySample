using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float moveSpeed;
    private float moveSpeedMin = 10f;
    private float moveSpeedMax = 15f;
    private Collider2D Collider2D;
    private float rotateSpeed;
    private float rotateSpeedMin = 30f;
    private float rotateSpeedMax = 40f;
    private void Awake()
    {
        Collider2D = GetComponent<Collider2D>();
        rotateSpeed = Random.Range(rotateSpeedMin, rotateSpeedMax);
    }
    private void Start()
    {
        moveSpeed = Random.Range(moveSpeedMin, moveSpeedMax);
    }
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime * moveSpeed);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Collider2D.isTrigger = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            Collider2D.isTrigger = true;
        }
    }
}
