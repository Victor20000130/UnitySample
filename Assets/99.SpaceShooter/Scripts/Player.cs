using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Player : MonoBehaviour
    {
        public float moveSpeed = 5;
        public float WeithMinSize = -13f;
        public float WeithMaxSize = 13f;
        public GameObject bulletPrefab;
        public GameObject gameOverMessage;
        public float bulletSpeed = 10;
        public float timeAfterStart;
        private Rigidbody2D rb;
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        private void Start()
        {
            timeAfterStart = 0f;
            StartCoroutine(BulletSpawn(bulletPrefab, 1));
        }
        private void Update()
        {
            timeAfterStart += Time.deltaTime;
            //Input : InputManager의 기능을 활용하여 입력 처리를 할 수 있는 클래스.
            //Input.GetAxis() : 미리 정의되어 있는 입력 축의 값을 가져옴.
            // 예 : Horizontal : X축, Vertical : Y축.

            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            transform.Translate(new Vector3(x, y) * Time.deltaTime * moveSpeed);

            //if (transform.position.x < WeithMinSize)
            //{
            //    transform.position = new Vector3(WeithMinSize, transform.position.y);
            //}
            //else if (transform.position.x > WeithMaxSize)
            //{
            //    transform.position = new Vector3(WeithMaxSize, transform.position.y);
            //}
            if(Input.GetKeyDown(KeyCode.Space))
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
        //private void OnCollisionEnter2D(Collision2D collision)
        //{
        //    if (collision.collider.CompareTag("Wall"))
        //    {
        //        //Enemy 태그를 가진 오브젝트와 충돌하면 -z 방향으로 튕겨나가고 싶다
        //        rb.AddForce(Vector3.negativeInfinity * 500f);
                
        //    }
        //}

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