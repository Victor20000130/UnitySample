using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public class Shape
{
    public Transform transform;
    
    public MeshFilter meshFilter;
    public MeshRenderer meshrenderer;

    public Mesh mesh;
    public Material material;

    public Vector3 position;
    public Color color;
}
public class RendererScripts : MonoBehaviour
{
    public List<Shape> shapes;

    private int positionMin = -5;
    private int positionMax = 5;
    private float colorMin = 0f;
    private float colorMax = 1f;
    private Vector3 setposition;
    private Quaternion rotation;
    private float timeAfterChange;
    private float timeRate;
    private float x, y, z, w;

    private float RandColor(float Min, float Max)
    {
        return UnityEngine.Random.Range(Min, Max);
    }
    private int RandPosition(int Min, int Max)
    {
        return UnityEngine.Random.Range(Min, Max);
    }
    void Start()
    {
        timeAfterChange = 0f;
        timeRate = 5;
        foreach (Shape shape in shapes)
        {
            shape.color.r = RandColor(colorMin, colorMax);
            shape.color.g = RandColor(colorMin, colorMax);
            shape.color.b = RandColor(colorMin, colorMax);
            shape.color.a = RandColor(colorMin, colorMax);
            x = RandPosition(positionMin, positionMax);
            y = RandPosition(positionMin, positionMax);
            z = RandPosition(positionMin, positionMax);
            w = RandPosition(positionMin, positionMax);
            setposition.Set(x, y, z);
            rotation.Set(x, y, z, w);
            shape.meshrenderer.material = shape.material;
            shape.meshrenderer.material.color = shape.color;
            shape.meshFilter.mesh = shape.mesh;
            shape.transform.SetLocalPositionAndRotation(setposition, rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterChange += Time.deltaTime;
        if (timeAfterChange >= timeRate)
        {
            timeAfterChange = 0f;
            foreach (Shape shape in shapes)
            {
                shape.color.r = RandColor(colorMin, colorMax);
                shape.color.g = RandColor(colorMin, colorMax);
                shape.color.b = RandColor(colorMin, colorMax);
                shape.color.a = RandColor(colorMin, colorMax);
                x = RandPosition(positionMin, positionMax);
                y = RandPosition(positionMin, positionMax);
                z = RandPosition(positionMin, positionMax);
                w = RandPosition(positionMin, positionMax);
                setposition.Set(x, y, z);
                rotation.Set(x, y, z, w);
                shape.meshrenderer.material = shape.material;
                shape.meshrenderer.material.color = shape.color;
                shape.meshFilter.mesh = shape.mesh;
                shape.transform.SetLocalPositionAndRotation(setposition, rotation);
            }
        }
    }
}
