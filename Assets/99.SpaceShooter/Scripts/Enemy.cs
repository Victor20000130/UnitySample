using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Enemy : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public SpriteRenderer myRenderer;
        public float spawnRateMin = 0.5f;
        public float spawnRateMax = 3f;

        public float WeithMinSize = -13f;
        public float WeithMaxSize = 13f;
        public float HeightMinSize = 5f;
        public float HeightMaxSize = 10f;

        private float spawnRate;
        private float timeAfterSpawn;


        private float moveSpeedMin = 5f;
        private float moveSpeedMax = 10f;


        public float moveSpeed;

        private Rigidbody2D rb;

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

            // if (transform.position.x < WeithMinSize)
            //{
            //    transform.position = new Vector3(WeithMinSize, transform.position.y);
            //}
            //else if (transform.position.x > WeithMaxSize)
            //{
            //    transform.position = new Vector3(WeithMaxSize, transform.position.y);
            //}

            //if (isTrue)
            //{
            //    transform.Translate(new Vector3(1, 0) * Time.deltaTime * moveSpeed);
            //    if (transform.position.x >= (WeithMaxSize - 1)) isTrue = false;
            //}
            //else if (isTrue == false)
            //{
            //    transform.Translate(new Vector3(-1, 0) * Time.deltaTime * moveSpeed);
            //    if (transform.position.x <= (WeithMinSize + 1)) isTrue = true;
            //}

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Wall"))
            {
                Collider2D.isTrigger = true;
            }
        }
    }
}