using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    
    MeshRenderer mr;
    
    public Material woodMaterial;
    public Material redMaterial;

    public Material stoneMaterial;

    public Transform transformTest;

    private Coroutine mat_ChangeCoroutine;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        stoneMaterial = mr.material;
    }

    void Start()
    {
        //��Ȯ�� 3�� �Ŀ� MeshRenderer�� Material�� woodMaterial�� ��ü�ϰ� �;��.
        var enumerator = StringEnumerator();
        //enumerator.MoveNext();
        //print(enumerator.Current);
        //enumerator.MoveNext();
        //print(enumerator.Current);
        //���� �Ʒ�ó�� �����.
        //while (enumerator.MoveNext())
        //{
        //    print(enumerator.Current);
        //}

        //List<int> intList = new List<int>() { 1, 2, 3 };
        //foreach (int someInt in intList) 
        //{
        //    print(someInt);
        //}

        //IEnumerator�� ����ϰ� �ִ� �ֵ��� �� ����� ������.
        //foreach (Transform someTransform in transformTest)
        //{
        //    print(someTransform.name);
        //}


        //StartCoroutine("MaterialChange");//�̰� ���� �ϼ�
        //�ڷ�ƾ�� �ڷ�ƾ�� ��ȯ�� �� �ִ�.
        //�ڷ�ƾ���� �Ű������� �÷��� ������ �� �ִ�.
        mat_ChangeCoroutine = StartCoroutine(MaterialChange(redMaterial, 1f));//���
        

    }


    void Update()
    {
        //if(Time.time > 3f)
        //{
        //    mr.material = woodMaterial;
        //}

        if(Input.GetButtonDown("Jump"))
        {
            mr.material = stoneMaterial;
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            print("�ڷ�ƾ ��ž");
            //StopCoroutine("MaterialChange");//�ϼ�
            StopCoroutine(mat_ChangeCoroutine);//���
        }
    }

    private IEnumerator<string> StringEnumerator()
    {
        //IEnumerator�� ��ȯ�ϴ� �Լ���
        //yield return Ű���带 ����
        //���� ���������� ��ȯ�� �� ����.
        yield return "a";
        yield return "b";
        yield return "c";
    }

    private IEnumerator MaterialChange(Material mat, float interval)
    {
        while (true)
        {
            //�ڷ�ƾ�� interval�� ��� �մϴ�.
            yield return new WaitForSeconds(interval);
            mr.material = mat;
        }
    }

}
