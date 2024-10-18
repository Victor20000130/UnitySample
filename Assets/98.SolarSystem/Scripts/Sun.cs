using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float sunRotation;
    void Start()
    {
        sunRotation = 0.1997f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(10f, 20f, 30f) * sunRotation * Time.deltaTime);

    }
}
