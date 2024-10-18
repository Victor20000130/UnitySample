using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class EnemySpawner : MonoBehaviour
{
    public Transform parent;
    public GameObject enemyPrefab;
    public Transform enemyTransform;

    
    public float WeithMinSize = -13f;
    public float WeithMaxSize = 13f;
    public float HeightMinSize = -8f;
    public float HeightMaxSize = 8f;
    public float enemySpeed = 3f;

    private float timeAfterspawn;
    private float spawnRate;
    private float spawnRateMin = 4f;
    private float spawnRateMax = 5f;


    public float moveSpeed = 5;
    bool isTrue = true;

    private void Start()
    {
        //StartCoroutine(RespawnEnemy(enemyPrefab, 3f));
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    private void Update()
    {
        timeAfterspawn += Time.deltaTime;

        if (timeAfterspawn >= spawnRate)
        {
            timeAfterspawn = 0f;
            GameObject enemy = Instantiate(enemyPrefab, parent);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }

        if (transform.position.x < WeithMinSize)
        {
            transform.position = new Vector3(WeithMinSize, transform.position.y);
        }
        else if (transform.position.x > WeithMaxSize)
        {
            transform.position = new Vector3(WeithMaxSize, transform.position.y);
        }

        if (isTrue)
        {
            transform.Translate(new Vector3(1, 0) * Time.deltaTime * moveSpeed);
            if (transform.position.x >= (WeithMaxSize - 1)) isTrue = false;
        }
        else if (isTrue == false)
        {
            transform.Translate(new Vector3(-1, 0) * Time.deltaTime * moveSpeed);
            if (transform.position.x <= (WeithMinSize + 1)) isTrue = true;
        }

    }
}
