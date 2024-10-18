using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] // C# Attribute : Ư�� ���(Ŭ����, ����, �Լ�)�� ���� ��Ÿ�����͸� ����
public class MyClass //�� Ŭ������ ���� �ٸ� ��������� �����ϱ� ���ؼ��� "����ȭ"�� �ʿ��ϴ�.
{
    public string name;
    public int id;
    public Sprite sprite;
}


public class ReferenceVariableTest : MonoBehaviour
{
    public MyClass myClass;

    public List<MyClass> myClasses;

    // Start is called before the first frame update
    void Start()
    {
        print(myClass); //print()�� Debug.Log()�� ���� ����� ��(MonoBehaviour�� ���Ե� ����)
        print(myClass.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
