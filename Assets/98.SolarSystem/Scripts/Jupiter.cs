using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jupiter : MonoBehaviour
{
    public GameObject satellite;
    public float moveSpeed;
    float revolution;
    float jupRotation;
    void Start()
    {
        revolution = 13.05624f;
        jupRotation = 12.6f;
        for (int i = 0; i < 66; i++)
        {
            GameObject clone = Instantiate(satellite, Vector3.zero, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
    }
    private void OnMove()
    {
        transform.Rotate(new Vector3(10f, 20f, 30f) * jupRotation * Time.deltaTime);
        transform.RotateAround(Vector3.zero, -Vector3.up, revolution * Time.deltaTime);
        //transform.GetChild()
    }
}
