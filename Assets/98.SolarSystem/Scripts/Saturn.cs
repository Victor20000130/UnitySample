using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saturn : MonoBehaviour
{
    public float moveSpeed;
    float revolution;
    float satRotation;
    void Start()
    {
        revolution = 9.639f;
        satRotation = 9.87f;
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
    }
    private void OnMove()
    {
        transform.Rotate(new Vector3(10f, 20f, 30f) * satRotation * Time.deltaTime);
        transform.RotateAround(Vector3.zero, -Vector3.up, revolution * Time.deltaTime);
    }
}
