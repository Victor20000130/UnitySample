using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformControlTest : MonoBehaviour
{
    public Transform target;

    // �⺻������ Transform�� postition, rotation, localScale ������Ƽ�� ����
    // �ش� ������Ʈ�� ��ġ, ����, ũ����� ������ �� �ִ�.

    private void Start()
    {
        //ControlStraightly();

        //ControlByDirection();
        //ControlByMethod();
    }

    //���� ���� �����Ͽ� Transform�� ����
    private void ControlStraightly()
    {
        transform.position = new Vector3(3, 2, 1);
        //transform.rotation = new Quaternion(0.3f, 0.02f, 0.001f, 0);
        transform.rotation = Quaternion.Euler(30, 20, 10);
        print(transform.rotation);
        transform.localScale = new Vector3(4, 5, 6);
    }


    //����(��,��,��,��,��,��)�� ���⺤�͸� �����Ͽ� Rotation ����
    private void ControlByDirection()
    {

        //Vector3 lookDir = target.position - transform.position;
        //�� ��ġ���� Target ��ġ�� �̵��ϱ� ���� ���ؾ� �ϴ� ���� ���͸� ����.

        //transform.up = target.position - transform.position; // �ش� ������ ���� Up�� ��.

        //�ش� ������ ���� right�� �Ƿ���?
        //transform.right = lookDir;
        //�ش� ������ ���� forward�� �Ƿ���?
        //transform.forward = lookDir;

        //�ش� ������ ���� down�� �Ƿ���?
        //transform.up = -lookDir;
        //�ش� ������ ���� left�� �Ƿ���?
        //transform.right = -lookDir;
        //�ش� ������ ���� backward�� �Ƿ���?
        //transform.forward = -lookDir;
    }

    //Transform�� ���� �Լ��� ȣ��
    private void ControlByMethod()
    {
        //Translate : Position�� �����ϴ� �Լ�
        transform.Translate(5,0,0);
        //Rotate : Rotation�� �����ϴ� �Լ�.
        transform.Rotate(30,0,0);

        //Translate, Rotate �Լ��� ����Ͽ� �����ϴ� ����
        //transform.position, rotation�� ���� ���� �Ҵ��ϴ� �Ͱ� �����ڸ�
        //���� position, rotation �������� ������� ������ �̷������ ������ �����ϸ� �ȴ�.
    }

    private void Update()
    {
        //Vector3 lookDir = target.position - transform.position;
        //transform.up = lookDir;
        transform.position = transform.position + new Vector3(3, 2, 1) * Time.deltaTime;
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles +
        //    new Vector3(30, 20, 10) * Time.deltaTime);

        transform.Translate(new Vector3(3, 2, 1) * Time.deltaTime);
        transform.Rotate(new Vector3(30, 20, 10) * Time.deltaTime);
    }

}
