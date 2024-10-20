using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorsSpawner : MonoBehaviour
{
    public GameObject[] meteorPrefab;
    private int spawnerDirection;
    private float timeAfterspawn;
    private float spawnRate;
    private float spawnRateMin = 15f;
    private float spawnRateMax = 30f;
    public float moveSpeed;
    public float moveSpeedMin = 5;
    public float moveSpeedMax = 10;

    private void Start()
    {
        moveSpeed = Random.Range(moveSpeedMin, moveSpeedMax);
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        spawnerDirection = Random.Range(-1, 2);
        while(spawnerDirection == 0)
        {
            spawnerDirection = Random.Range(-1, 2);
        }
    }
    private void Update()
    {
        timeAfterspawn += Time.deltaTime;
        transform.Translate(new Vector2(spawnerDirection, 0) * Time.deltaTime * moveSpeed);
        if (timeAfterspawn >= spawnRate)
        {
            int i = Random.Range(0, 4);
            timeAfterspawn = 0f;
            Instantiate(meteorPrefab[i], transform.position, Quaternion.identity);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            if (spawnerDirection == -1) { spawnerDirection = 1; }
            else { spawnerDirection = -1; }
        }
    }
}
