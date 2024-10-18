using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class BuiltinClassesTest : MonoBehaviour
{

    //����Ƽ �������� �����ϴ� ���̺귯���� ����� Ŭ������ Ȱ��.
    //Debug : ����뿡 ���Ǵ� ����� �����ϴ� Ŭ����.

    void Start()
    {
        //Debug.Log($"Log{1}");
        //Debug.LogWarning("");
        //Debug.LogError("");
        //Debug.LogFormat("{0}, {1}", 3, 5.0);//xxFormat���� ������ �Լ��� : �Ķ���͸� ���˿� ���� ġȯ�ϴ� ���ڿ�
        //Debug.DrawLine(Vector3.zero, new Vector3(0, 3), Color.magenta, 5f); : ������ǥ���� ��ǥ��ǥ���� ���� �׸���.
        //Debug.DrawRay(Vector3.zero, new Vector3(0, 5), Color.magenta, 10f); : ������ǥ���� ���������� ���� �׸���

        //Mathf : UnityEngine���� �����ϴ� �پ��� ���� ���� �Լ��� ���Ե� Ŭ����.
        //Mathf.Abs() : ���밪 ��ȯ
        float a = -0.3f;
        a = Mathf.Abs(a);
        print(a);
        a = Mathf.Abs(+0.3f);
        print(a);

        //�ٻ簪 ��. �Ǽ��� �ٻ簪 ��. ��Ȯ�� �������� �˻��� �� �����Ƿ� �ٻ簪�� �˻��ϱ� ���� �����.
        print(1.1f + 0.1f == 1.2f);
        print(Mathf.Approximately(1.1f + 0.1f, 1.2f));

        //Mathf.Lerp(a, b, t) : ���� ����([L]inear Int[erp]olation)
        //a���� b �� ������ t�� ������ŭ�� ��ġ�ϴ� ��.(0<t<1)
        print(Mathf.Lerp(-1f, 1f, 0.5f));
        //Lerp(���� ����)�Լ��� Color, Vector(2, 3, 4), Material, Quaternion ���� Ŭ�������� ������.
        Mathf.InverseLerp(0, 0, 0); // Lerp�� a, b �Ķ���Ͱ� �ݴ�

        //Mathf.Ceil, Floor, Round : �ø�, ����, �ݿø�

        float value = 5.4f;

        float ceil = Mathf.Ceil(value);
        float floor = Mathf.Floor(value);
        float round = Mathf.Round(value);
        print($"Ceil : {ceil}, Floor : {floor}, Round : {round}");

        //print(Mathf.Sign(value)); // ��ȣ
        //print(Mathf.Sin(value)); // �ﰢ�Լ� ����
        //print(Mathf.Pow(value, 1.2f)); // �ŵ�����
        //print($"Deg2Rad * value : {Mathf.Deg2Rad * value}");
        //print($"Rad2Deg * value : {Mathf.Rad2Deg * value}");

        //Random : ������ �����ϴ� Ŭ����.
        //System.Random r = new System.Random(); // .net �����ӿ�ũ���� �����ϴ� ����
        //random.Next();

        //int�� ��ȯ�ϴ� Range�Լ��� �ִ밪�� �����ϰ� ��ȯ
        int intRandom = Random.Range(-1, 1); // -1, 0 �� ����

        //float�� ��ȯ�ϴ� Range�Լ��� �ִ밪�� ���ٰ� ���ֵǴ� ���� ��ȯ�� ���� ����
        float floatRandom = Random.Range(-1f, 1f); // -1.00..1 ~ 0.99... ���� Max���� ���ϵ� �� ����

        float randomValue = Random.value; // == Random.Range(0f,1f); ����� Ȯ���� ���ϰ� ��� ���� ���

        Vector3 randomPosition = Random.insideUnitSphere * 5f; // * 5f �� ����� ���ϴ°�
        //Vector3(-1~1, -1~1, -1~1); ������ ��ġ�� �̰� ���� �� ȿ����.

        Vector3 randomDirection = Random.onUnitSphere;
        // ������ Vector3�� ���µ�, ���̰� �׻� 1. ������ "����"�� �̰� ���� �� ȿ����.

        Vector2 randomPosition2D = Random.insideUnitCircle;
        // 2D�� Random Vector

        //Random.rotation;

        Random.InitState(11234); // ������ �õ尪 �ʱ�ȭ.
        //���� ���ϰ� ���� �ɸ��� �Լ��̹Ƿ�, ���������� (�� �ε� �ʱ⶧�뿡��) ����� ��.

    }

    //Gizmos : Sceneâ������ �� �� �ִ� "�����"�� �׸��� Ŭ����.(Debug.DrawXX�� Ȯ����ó��)

    void Update()
    {
        Gizmos.DrawCube(Vector3.zero, Vector3.one); // <<--�ǹ� ����
    }

    
    //Gizmos Ŭ������ OnDrawGizmos, OnDrawGizmosSelected, OnSceneGUI�� Sceneâ�� �����Ϳ�����
    //Ȱ��ȭ �Ǵ� �޼��� �Լ������� ��ȿ�ϰ� �����.
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Vector3.zero, Mathf.PI);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(Vector3.one, 0.5f);
    }

}
