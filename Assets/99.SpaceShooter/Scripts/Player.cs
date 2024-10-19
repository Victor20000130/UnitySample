using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Player : MonoBehaviour
    {
        public float moveSpeed = 5;
        public GameObject bulletPrefab;
        public GameObject gameOverMessage;
        public float bulletSpeed = 10;
        private Rigidbody2D rb;
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        private void Start()
        {
            StartCoroutine(BulletSpawn(bulletPrefab, 1));
        }
        private void Update()
        {
            //Input : InputManager�� ����� Ȱ���Ͽ� �Է� ó���� �� �� �ִ� Ŭ����.
            //Input.GetAxis() : �̸� ���ǵǾ� �ִ� �Է� ���� ���� ������.
            // �� : Horizontal : X��, Vertical : Y��.

            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            rb.MovePosition(rb.position + (new Vector2(x, y) * Time.deltaTime * moveSpeed));
            if (Input.GetKeyDown(KeyCode.Space))
            {

            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                //print("���� ����");
                //GameOver();
            }
        }
        public void GameOver()
        {
            gameOverMessage.SetActive(true);
            Time.timeScale = 0f;
        }

        private IEnumerator BulletSpawn(GameObject bullet, float interval)
        {
            while (true)
            {
                yield return new WaitForSeconds(interval);
                bullet = Instantiate(bulletPrefab);
                bullet.transform.position = transform.position;
            }
        }
    }
}