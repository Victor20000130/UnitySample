using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMessageTest : MonoBehaviour
{

    //1. Update : �� �������� ���� ó�� ȣ��
    private float preFrameTime = 0; // ���� �������� ȣ��� �ð�
    private void Update()
    {
        //Time.time : ������ ���۵� �ڷ� 1�ʴ� 1f�� �ӵ��� ����.
        print($"Update ȣ���. ȣ��ð� : {Time.time}, ���� �����Ӱ� �ð����� : {Time.time - preFrameTime}");
        preFrameTime = Time.time;

        print($"DeltaTime : {Time.deltaTime}");
    }
    //2. FixedUpdate : ���� ������ �����Ӱ� ������ ���� ������ ����� ������ ȣ��. ȣ�� �ֱⰡ ������.
    private float prePhysicsFrameTime = 0;
    private void FixedUpdate()
    {
        print($"FixedUpdate ȣ���. ȣ��ð� : {Time.time}, ���� �����Ӱ� �ð����� : {Time.time - prePhysicsFrameTime}");
        prePhysicsFrameTime = Time.time;
        print($"FixedDeltaTime : {Time.fixedDeltaTime}");
    }

    //3. LateUpdate : �� �������� ���� ���߿� ȣ��.
    //���� �����ӿ��� ȣ��ǹǷ� Update�� ȣ�� ������ �ٸ����� �ð����̴� ũ�� ����.
    private float preFrameLateTime = 0;
    private void LateUpdate()
    {
        print($"LateUpdate ȣ���. ȣ��ð� : {Time.time}, ���� �����Ӱ� �ð����� : {Time.time - preFrameLateTime}");
        preFrameLateTime = Time.time;
    }
}
