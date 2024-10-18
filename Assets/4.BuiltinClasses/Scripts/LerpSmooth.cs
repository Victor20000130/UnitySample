using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpSmooth : MonoBehaviour
{
    public Transform followTarget;
    public float moveSpeed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, followTarget.position,
            Time.deltaTime * moveSpeed);
        //0.02 * 3 = 0.05~0.06
        // ���� ����������� ���� ������ŭ �̵��� �� ���� �۾����� ������ �ӵ��� ��������.
        // �ݴ�� �־������� ��󿡰� �̵��� ���� Ŀ���� �ش��ϴ� ������ŭ �ӵ��� ��������.


    }
}
