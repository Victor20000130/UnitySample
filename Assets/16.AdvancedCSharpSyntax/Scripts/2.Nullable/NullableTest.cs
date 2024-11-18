using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable IDE0051 // �������� private ��� ����

namespace MyProject
{
    //nullable ���� : ? �����ڸ� ���� Ȱ���ؾ���.
    public class NullableTest : MonoBehaviour
    {
        public bool isBlue;

        private Renderer rend;

        //���ͷ� Ÿ��(��Ÿ��) �ʵ带 ��üó�� null �Ǵ� �ּ� (Instance hash)�� ����ϰ� ���� ��
        //���� C++�� �����Ϳ� ����� ���·� ���� ���� ��, type �ڿ� ? ���̰�, �̸� nullable type�̶�� ��

        private int? nullableInt;
        private int normalInt;

        private MyClass myClass;
        private Vector2? nullableVector;

        private void Awake()
        {
            rend = GetComponent<Renderer>();
        }

        private void Start()
        {
            //1. 3�� ������ : bool ? ���� true : ���� false;
            rend.material.color = isBlue ? Color.blue : Color.red;

            //2. ?. ?? : null üũ ���.
            //a. ��ü?.�Լ�();
            MyClass myClass1 = null;
            myClass1?.GetA();
            myClass1 = new MyClass() { a = 1 };
            myClass1?.GetA();
            //b-1. ��ġ?.�����ʵ� : �ʵ尡 ����Ÿ���� ��쿡�� ����.
            //��ü�� null�� ��� NullReferenceException�� ����� ��� �׳� null�� ����.
            myClass1 = null;
            GameObject someObj = myClass1?.obj;
            print(someObj);

            //b-2. ��ü?.�����ʵ�??�ٸ��ʵ�Ǵ°�ü : ��ü�� null�� ���, ??���� ���� ���� ��.
            GameObject someObj2 = myClass1?.obj ?? new GameObject();
            print(someObj2);

            //c. ��ü?.���ʵ�??(�ʼ�)��ü �� : ��ü�� null�� ���,
            //�����ϴ� �ʵ尡 ���ͷ� Ÿ���̶�� ������ ��ü ���� �����Ǿ�� ��.
            int someInt = myClass1?.a ?? 1;

            print(someInt);

            if (false == isBlue)
            {
                _ = StartCoroutine("");
            }

            if (myClass1 != null) { someObj = myClass1.obj; }
            else { someObj = new GameObject(); }

            print($"nullableInt : {nullableInt}");
            print($"normalInt : {normalInt}");

            string intToText = 1.ToString();
            intToText = nullableInt.ToString() ?? 0.ToString();
            print(intToText);

            nullableInt = 2;

            int localInt = 3;
            nullableInt = localInt;

            localInt = nullableInt.Value;
            print(localInt);

            nullableInt = null; //nullable ������ null�� �����ؼ� ������ ���.

            localInt = nullableInt ?? 0;

            if (nullableInt.HasValue)
            {//��������� null üũ
                localInt = nullableInt.Value;//������ �����غ��� null�̱� ������ ������ �ȵ�.
            }
            else { localInt = 0; }

            print($"nullableInt has Value? : {nullableInt.HasValue}");
            print(localInt);
        }

        public class MyClass
        {
            public int a;
            public GameObject obj;
            public MyClass()
            {
                obj = new GameObject();
                obj.name = "myClass";
            }
            public int GetA()
            {
                Debug.Log("Return A");
                return a;

            }
        }
    }
}