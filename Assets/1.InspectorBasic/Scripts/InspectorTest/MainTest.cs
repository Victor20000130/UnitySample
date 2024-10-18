using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class MyShape
{
    public Transform transform;

    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;

    public Vector3 startPosition;
    public Mesh mesh;
    public Material material;
}

public class MainTest : MonoBehaviour
{
    public List<MyShape> shapes;

    // Start is called before the first frame update
    void Start()
    {
        foreach (MyShape shape in shapes)   
        {
            shape.meshFilter.mesh = shape.mesh;
            shape.meshRenderer.material = shape.material;
            shape.transform.position = shape.startPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
