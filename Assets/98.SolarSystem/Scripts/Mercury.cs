using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mercury : MonoBehaviour
{
    public float moveSpeed;
    float revolution;
    float merRotation;

    // Start is called before the first frame update
    void Start()
    {
        revolution = 47.36f;
        merRotation = 0.003025f;
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
    }  

    private void OnMove()
    {
        transform.Rotate(new Vector3(10f, 20f, 30f) * merRotation * Time.deltaTime);
        transform.RotateAround(Vector3.zero, -Vector3.up, revolution * Time.deltaTime);
    }
}
