using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineSamples : MonoBehaviour
{
    private void Start()
    {
        //StartCoroutine(ReturnNull());
        //StartCoroutine(ReturnWaitForSec(1f, 5));
        //StartCoroutine(ReturnWaitForSecRealTime(1f, 5));
        //StartCoroutine(ReturnUntilWhile());
        //StartCoroutine(ReturnEndOfFrames());
        //StartCoroutine(ReturnFixedUpdate());
        StartCoroutine(_1st());
    

    
    }

    //yield return null : �� �����Ӹ��� ���� yield return�� ��ȯ
    private IEnumerator ReturnNull()
    {
        print("ReturnNull �ڷ�ƾ�� ���۵Ǿ����ϴ�.");
        while (true)
        {
            yield return null;
            print($"Return null �ڷ�ƾ�� ����Ǿ����ϴ� {Time.time}");
        }
    }

    //yield return new WaitForSeconds()
    // : �ڷ�ƾ�� yield return Ű���带 ������ �Ķ���͸�ŭ ��� �� ����
    private IEnumerator ReturnWaitForSec(float interval, int count)
    {
        print("ReturnWaitForSec �ڷ�ƾ�� ���۵Ǿ����ϴ�.");
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(interval);
            print($"ReturnWaitForSec {i + 1}�� ȣ���.{Time.time}");
        }
        print("ReturnWaitForSec �ڷ�ƾ ��.");

    }

    //yield return new WaitForSecondsRealTime(param) :
    //WaitForSeconds�� ������ ������ TimeScale�� ���� ���� �ʴ´�.
    private IEnumerator ReturnWaitForSecRealTime(float interval, int count)
    {
        print("ReturnWaitForSecRealTime �ڷ�ƾ�� ���۵Ǿ����ϴ�.");
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSecondsRealtime(interval);
            print($"ReturnWaitForSecRealTime {i + 1}�� ȣ���.{Time.time}");
        }
        print("ReturnWaitForSecRealTime �ڷ�ƾ ��.");
    }

    public bool continueKey;

    private bool IsContienue()
    {
        return continueKey;
    }

    //yield return new WaitUntil / WaitWhile (param) : Ư�� ������ True/False�� �ɶ����� ���
    private IEnumerator ReturnUntilWhile()
    {
        print("ReturnUntilWhile �ڷ�ƾ ���� ��.");
        while (true)
        {
            //new WaitUntil : �������� �Ű������� �Ѿ �Լ�(�븮��)��
            //return�� false�� ���� ���, true�� �Ѿ.
            yield return new WaitUntil(()=>continueKey);
            print("��Ƽ�� Ű�� True");
            //new WaitWhile : �������� �Ű������� �Ѿ �Լ�(�븮��)��
            //return�� true�� ���� ���, false�� �Ѿ.
            yield return new WaitWhile(IsContienue);
            print("��Ƽ�� Ű�� False");
        }
    }

    //yield return new (Frame �迭) : �� ������ Ư�� ������ �ڿ� �����.
    private IEnumerator ReturnEndOfFrames()
    {
        //EndOfFrame : �ش� �������� ���� ���������� ��ٸ�.
        yield return new WaitForEndOfFrame();
        print("End of Frame");
        isFirstFrame = false;
    }

    private IEnumerator ReturnFixedUpdate()
    {
        //FixedUpdate : ���������� ���� ������ ��ٸ�.
        yield return new WaitForFixedUpdate();
    }

    bool isFirstFrame = false;
    private void Update()
    {
        if (isFirstFrame)
        {
            print("Update �޼��� �Լ� ȣ��");
        }
    }
    private void LateUpdate()
    {
        if(isFirstFrame)
        {
            print("LateUpdate �޼��� �Լ� ȣ��");
        }
    }

    //yield return �ڷ�ƾ : �ش� �ڷ�ƾ�� ���������� ���.

    private IEnumerator _1st()
    {
        print("1��° �ڷ�ƾ ���۵�");
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(1f);
            print($"1��° �ڷ�ƾ {i + 1}��° �����.");
        }
        print("1��° �ڷ�ƾ�� 2��° �ڷ�ƾ�� �����ϰ� �����");
        yield return StartCoroutine(_2nd());
        print("1��° �ڷ�ƾ ����");
    }

    Coroutine _3rdCoroutine;

    private IEnumerator _2nd()
    {
        print("2��° �ڷ�ƾ ���۵�");
        print("2��° �ڷ�ƾ�� 3��° �ڷ�ƾ�� �����ϰ� �����");
        _3rdCoroutine = StartCoroutine(_3rd());
        yield return _3rdCoroutine;
        //yield return StartCoroutine(_3rd());
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1f);
            print($"2��° �ڷ�ƾ {i + 1}��° �����.");
        }
        print("2��° �ڷ�ƾ ����");
    }
    private IEnumerator _3rd()
    {
        print("3��° �ڷ�ƾ ���۵�");
        for(int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1f);
            print($"3��° �ڷ�ƾ {i + 1}��° �����.");
        }
        print("3��° �ڷ�ƾ ����");
    }

}
    