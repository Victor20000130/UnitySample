using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uranus : MonoBehaviour
{
    public float moveSpeed;
    float revolution;
    float uraRotation;
    void Start()
    {
        revolution = 6.795f;
        uraRotation = 2.59f;
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
    }
    private void OnMove()
    {
        transform.Rotate(new Vector3(10f, 20f, 30f) * uraRotation * Time.deltaTime);
        transform.RotateAround(Vector3.zero, -Vector3.up, revolution * Time.deltaTime);
    }
}
