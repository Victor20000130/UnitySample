using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Enemy : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public SpriteRenderer myRenderer;

        private float moveSpeedMin = 5f;
        private float moveSpeedMax = 10f;

        public float moveSpeed;

        private Collider2D Collider2D;

        private void Awake()
        {
            Collider2D = GetComponent<Collider2D>();
        }
        private void Start()
        {
            moveSpeed = Random.Range(moveSpeedMin, moveSpeedMax);
        }
        private void Update()
        {
            transform.Translate(new Vector3(0, -0.5f, 0) * Time.deltaTime * moveSpeed);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("WallDown"))
            {
                Collider2D.isTrigger = true;
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
           if (other.CompareTag("WallUp"))
            {
                Collider2D.isTrigger = false;
            }
        }
    }
}