using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour
{
    public Transform parent;
    public GameObject obj;
    public float moveSpeed;
    float revolution;
    float Rotation;
    void Start()
    {
        Vector3 randomsphear = Random.onUnitSphere * 0.5f;
        transform.position = parent.position + randomsphear;
        transform.localScale = new Vector3(parent.localScale.x * 0.6f, parent.localScale.y * 0.6f, parent.localScale.z * 0.6f);
        revolution = 0.2f;
        Rotation = 0.1f;
    }

    void Update()
    {
        OnMove();
    }
    private void OnMove()
    {
        transform.Rotate(new Vector3(10f, 20f, 30f) * Rotation * Time.deltaTime);
        transform.RotateAround(obj.transform.position, -Vector3.up, revolution * Time.deltaTime);
        
    }
}