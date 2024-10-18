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
            //Input : InputManager�� ����� Ȱ���Ͽ� �Է� ó���� �� �� �ִ� Ŭ����.
            //Input.GetAxis() : �̸� ���ǵǾ� �ִ� �Է� ���� ���� ������.
            // �� : Horizontal : X��, Vertical : Y��.

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
                //print("���� ����");
                //GameOver();
            }
        }
        //private void OnCollisionEnter2D(Collision2D collision)
        //{
        //    if (collision.collider.CompareTag("Wall"))
        //    {
        //        //Enemy �±׸� ���� ������Ʈ�� �浹�ϸ� -z �������� ƨ�ܳ����� �ʹ�
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