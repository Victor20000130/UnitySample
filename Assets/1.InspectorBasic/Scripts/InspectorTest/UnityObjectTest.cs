using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityObjectTest : MonoBehaviour
{
    public GameObject testObject;


    public Transform cubeTransform;
    public MeshRenderer cubeMeshRenderer;
    public MeshFilter cubeMeshFilter;
    public BoxCollider cubeBoxCollider1;
    public BoxCollider cubeBoxCollider2;

    public object systemObject; //C#�� object : ��� Ŭ������ Parent

    public Object unityObject; //����Ƽ �������� Ȱ���ϴ� ��� ������Ʈ

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Test Object value : {testObject}");

        Debug.Log($"Collider1 : {cubeBoxCollider1.center.z}");
        Debug.Log($"Collider2 : {cubeBoxCollider2.center.z}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
