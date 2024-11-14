using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGUIButton : MonoBehaviour
{
    //Button ������Ʈ�� OnClick() �̺�Ʈ�� �Ҵ��Ͽ� �ش� ��ư�� Ŭ���� ������ ȣ�� �ǵ���
    //"����Ƽ ������" Inspector�� �Ҵ�� ��� �������� �������ش�.
    //Inspector���� �ش� �Լ��� �����Ϸ��� ���� �����ڰ� public�̾�� ��.
    //�̹� ������ �Ŀ� private�� �ٲٸ� �״�� ������ �Ǳ� ��. ������ Inspector�󿡼��� ã�� �� ����.
    public void ButtonClick() //�� �Լ��� ��ư�� Ŭ���� �� ȣ��.
    {
        print("��ư Ŭ����.");
    }
    public void ButtonClickWithParam(string param)
    {
        print($"��ư Ŭ����. �Ķ���� : {param}");
    }

    public void ButtonClickWithFloatParam(float param)
    {
        print($"��ư Ŭ����. �Ķ���� : {param}");
    }
    public void ButtonClickWithBoolParam(bool param)
    {
        print($"��ư Ŭ����. �Ķ���� : {param}");

    }
}
