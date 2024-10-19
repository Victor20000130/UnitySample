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
            //Input : InputManager의 기능을 활용하여 입력 처리를 할 수 있는 클래스.
            //Input.GetAxis() : 미리 정의되어 있는 입력 축의 값을 가져옴.
            // 예 : Horizontal : X축, Vertical : Y축.

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
                //print("게임 오버");
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