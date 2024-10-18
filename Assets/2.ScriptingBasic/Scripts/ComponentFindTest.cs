using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentFindTest : MonoBehaviour
{
    //���� ������Ʈ�� �˰� �ִ� ���¿��� �ش� ������Ʈ�� ���� ������Ʈ�� ã������ ���

    public GameObject target;

    private FindMe findMe;

    private void Start()
    {
        //target ������Ʈ���� FindMe ������Ʈ�� ã���� �Ҷ�
        //���׸��� ���� typeof�� �ڽ�/��ڽ��� ���ϰ� ã�� �� ����
        findMe = target.GetComponent<FindMe>();
        print(findMe.message);

        bool isFinded = target.TryGetComponent<BoxCollider>(out BoxCollider boxCollider);
        
        if (isFinded)
        {
            print($"Box Collider�� ã�ҽ��ϴ�. {boxCollider}");
        }
        else
        {
            print($"Box Collider�� ã�� ���߽��ϴ�.{boxCollider}");
        }
        
        //target.GetComponentInChildren<FindMe>();
        FindMe[] children = target.GetComponentsInChildren<FindMe>();
        foreach (FindMe child in children) 
        {
            print(child.message);
        }
        FindMe newFindMe = target.AddComponent<FindMe>();
        newFindMe.message = "�ٽ� ���� ã���̱���!";

        //Destroy �Լ��� ����, ���� ������Ʈ�� �ƴ϶� ������Ʈ�� ������ ���� ����.
        Destroy(findMe, 2f);
        //������Ʈ �Ӹ��� �ƴ϶� ���� ������Ʈ ��ü�� ������ ���� ����.
        Destroy(findMe.gameObject, 2f);
    }
}
