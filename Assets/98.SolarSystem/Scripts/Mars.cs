using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mars : MonoBehaviour
{
    public GameObject sattllite;
    public float moveSpeed;
    float revolution;
    float marRotation;
    void Start()
    {
        revolution = 24.077f;
        marRotation = 0.241172f;
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
    }
    private void OnMove()
    {
        transform.Rotate(new Vector3(10f, 20f, 30f) * marRotation * Time.deltaTime);
        transform.RotateAround(Vector3.zero, -Vector3.up, revolution * Time.deltaTime);
    }
}
