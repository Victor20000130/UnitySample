using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Player : MonoBehaviour
    {
        public float moveSpeed = 5;
        public GameObject bulletPrefab;
        public GameObject missilePrefab;

        public GameObject gameOverMessage;

        public GameObject playerDamaged;
        private Sprite[] damagedSprites;
        private int damageCounter = 0;

        private float skillColldown;

        public float bulletSpeed = 10;
        private Rigidbody2D rb;
        private void Awake()
        {
            damagedSprites = Resources.LoadAll<Sprite>("Damaged");
            rb = GetComponent<Rigidbody2D>();
        }
        private void Start()
        {
            StartCoroutine(BulletSpawn(bulletPrefab, 1));
        }
        private void Update()
        {
            skillColldown += Time.deltaTime;
            //Input : InputManager�� ����� Ȱ���Ͽ� �Է� ó���� �� �� �ִ� Ŭ����.
            //Input.GetAxis() : �̸� ���ǵǾ� �ִ� �Է� ���� ���� ������.
            // �� : Horizontal : X��, Vertical : Y��.

            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            rb.MovePosition(rb.position + (new Vector2(x, y) * Time.deltaTime * moveSpeed));
            if (skillColldown >= 5)
            {
                if (Input.GetKeyDown(KeyCode.Space)) 
                { 
                    MissileSpawn(missilePrefab);
                    skillColldown = 0;
                }
            }

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Enemy"))
            {
                Debug.Log("���� �浹");
                playerDamaged.GetComponent<SpriteRenderer>().sprite = damagedSprites[damageCounter];
                damageCounter++;
            }
            Debug.Log($"�浹 Ƚ�� : {damageCounter}");
            if (damageCounter == 3)
            {
                print("���� ����");
                Time.timeScale = 0f;
                gameOverMessage.SetActive(true);
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

        private void MissileSpawn(GameObject missile)
        {
            missile = Instantiate(missilePrefab);
            missile.transform.position = transform.position;
        }

    }
}