using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityStructTest : MonoBehaviour
{
    //����Ƽ ���� ����ü : ����Ƽ�� ������ ���� ���� �󿡼� ����ϰ� ���̴� ������ ����ü
    //1. Vector2 : 2���� �󿡼��� ��ǥ �Ǵ� ���� ũ�⸦ ��Ÿ���� ���� ����ü.
    public Vector2 vector2;

    //2. Vector3 : 3���� (��).
    public Vector3 vector3;

    //3. Vector4 : 4���� (��).
    public Vector4 vector4;

    //4. Quaternion : 4����. 3���� ���� ���� 1���� ����θ� �̿��Ͽ�
    //                  3���� �������� ���� ���� ���� ��ġ�� "������" ������ �����ϱ� ���� Rotation ������ ���.
    public Quaternion quat;

    //5. Vector2(3)Int : 2(3)���� �󿡼��� ��ǥ, �׷��� ���� ������ �����..
    public Vector2Int v2Int;
    public Vector3Int v3Int;

    //6. Color : ��
    public Color color;


    // Start is called before the first frame update
    void Start()
    {
        print($"{name}'s position : {transform.position}");
        print($"{name}'s rotation : {transform.rotation.eulerAngles}");
        print($"{name}'s scale : {transform.localScale}");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
