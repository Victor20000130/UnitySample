using SpaceShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace SpaceShooter
{
    public class PlayerBullet : MonoBehaviour
    {
        
        public float speed = 5f;
        private float timeAfterSpawn;

        private void Start()
        {
            timeAfterSpawn = 0f;
        }

        private void Update()
        {
            timeAfterSpawn += Time.deltaTime;
            transform.position += new Vector3(0f, speed * Time.deltaTime ,0f);
            if (timeAfterSpawn > 6f)
            {
                Destroy(gameObject);
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                Destroy(base.gameObject);
            }
            if (other.CompareTag("Wall"))
            {
                Destroy(base.gameObject);
            }
            if (other.CompareTag("Meteor"))
            {
                Destroy(base.gameObject);
            }
        }
    }
}
