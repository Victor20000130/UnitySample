using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityAttributeTest : MonoBehaviour
{
    //����Ƽ���� �����ϴ� ��Ʈ����Ʈ(Attribute)

    //1. SerializeField : �Ϲ������� �ν����Ϳ��� ���������ϴ� Private �Ǵ� Protected ������
    //Inspector���� �����ϵ��� �ϴ� ���
    [SerializeField]
    private int privateIntVar;

    //2. TextArea : Inspector���� ���ڿ� �Է¶��� 1���� �ƴ϶� ���� �ٷ� �Է��� �����ϵ��� ǥ��
    [TextArea(1, 5)]
    public string text;

    //3. Header : Inspector���� �߰��� Ư�� ���� ��������
    [Header("��� �׽�Ʈ")]
    public int otherIntVar;

    //4. Space : Inspector���� �Է�ĭ ���̿� ������ ���
    [Space(50)]
    public float floatVar;

    //5. Range : int �Ǵ� float ������ �ִ�/�ּҰ��� �����ϸ�, �����̴��ٷ� ���� �ٲ� �� �ֵ��� ����.
    [Range(0, 1)]
    public float rangedFloat;

    [Range(-5, 5)]
    public int rangedInt;

    //6. Tooltip : Inspector���� �ش� ������ ���콺�� �ø� ��� ������ �����
    [Tooltip("�̰��� �����Դϴ�.")]
    public string otherText;

    //7. HideInInspector : �ܺ� ��ü���� ������ �����ϳ� Inspector���� ���� ������ �� ��.
    //���� : Debug��忡���� ���� �� �� ����.
    [HideInInspector]
    public int publicIntVar;

    //internal ���������� : ���� �����(���ӽ����̽�) �������� ���� ������ ����������
    internal int internalIntVar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
