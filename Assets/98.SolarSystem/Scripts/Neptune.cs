using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neptune : MonoBehaviour
{
    public float moveSpeed;
    float revolution;
    float nepRotation;
    void Start()
    {
        revolution = 5.43f;
        nepRotation = 2.68f;
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
    }
    private void OnMove()
    {
        transform.Rotate(new Vector3(10f, 20f, 30f) * nepRotation * Time.deltaTime);
        transform.RotateAround(Vector3.zero, -Vector3.up, revolution * Time.deltaTime);
    }
}
