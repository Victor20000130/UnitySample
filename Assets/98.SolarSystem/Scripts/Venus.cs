using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Venus : MonoBehaviour
{
    public float moveSpeed;
    float revolution;
    float venRotation;
    void Start()
    {
        revolution = 35.020f;
        venRotation = 0.001811f;
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
    }
    private void OnMove()
    {
        transform.Rotate(new Vector3(10f, 20f, 30f) * venRotation * Time.deltaTime);
        transform.RotateAround(Vector3.zero, -Vector3.up, revolution * Time.deltaTime);
    }
}
