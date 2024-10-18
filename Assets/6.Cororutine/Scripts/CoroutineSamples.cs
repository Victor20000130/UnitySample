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

    //yield return null : 매 프레임마다 다음 yield return을 반환
    private IEnumerator ReturnNull()
    {
        print("ReturnNull 코루틴이 시작되었습니다.");
        while (true)
        {
            yield return null;
            print($"Return null 코루틴이 수행되었습니다 {Time.time}");
        }
    }

    //yield return new WaitForSeconds()
    // : 코루틴이 yield return 키워드를 만나면 파라미터만큼 대기 후 수행
    private IEnumerator ReturnWaitForSec(float interval, int count)
    {
        print("ReturnWaitForSec 코루틴이 시작되었습니다.");
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(interval);
            print($"ReturnWaitForSec {i + 1}번 호출됨.{Time.time}");
        }
        print("ReturnWaitForSec 코루틴 끝.");

    }

    //yield return new WaitForSecondsRealTime(param) :
    //WaitForSeconds와 동작은 같으나 TimeScale에 영향 받지 않는다.
    private IEnumerator ReturnWaitForSecRealTime(float interval, int count)
    {
        print("ReturnWaitForSecRealTime 코루틴이 시작되었습니다.");
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSecondsRealtime(interval);
            print($"ReturnWaitForSecRealTime {i + 1}번 호출됨.{Time.time}");
        }
        print("ReturnWaitForSecRealTime 코루틴 끝.");
    }

    public bool continueKey;

    private bool IsContienue()
    {
        return continueKey;
    }

    //yield return new WaitUntil / WaitWhile (param) : 특정 조건이 True/False가 될때까지 대기
    private IEnumerator ReturnUntilWhile()
    {
        print("ReturnUntilWhile 코루틴 시작 됨.");
        while (true)
        {
            //new WaitUntil : 생성자의 매개변수로 넘어간 함수(대리자)의
            //return이 false인 동안 대기, true면 넘어감.
            yield return new WaitUntil(()=>continueKey);
            print("컨티뉴 키가 True");
            //new WaitWhile : 생성자의 매개변수로 넘어간 함수(대리자)의
            //return이 true인 동안 대기, false면 넘어감.
            yield return new WaitWhile(IsContienue);
            print("컨티뉴 키가 False");
        }
    }

    //yield return new (Frame 계열) : 인 게임의 특정 프레임 뒤에 수행됨.
    private IEnumerator ReturnEndOfFrames()
    {
        //EndOfFrame : 해당 프레임의 가장 마지막까지 기다림.
        yield return new WaitForEndOfFrame();
        print("End of Frame");
        isFirstFrame = false;
    }

    private IEnumerator ReturnFixedUpdate()
    {
        //FixedUpdate : 물리연산이 끝날 때까지 기다림.
        yield return new WaitForFixedUpdate();
    }

    bool isFirstFrame = false;
    private void Update()
    {
        if (isFirstFrame)
        {
            print("Update 메세지 함수 호출");
        }
    }
    private void LateUpdate()
    {
        if(isFirstFrame)
        {
            print("LateUpdate 메세지 함수 호출");
        }
    }

    //yield return 코루틴 : 해당 코루틴이 끝날때까지 대기.

    private IEnumerator _1st()
    {
        print("1번째 코루틴 시작됨");
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(1f);
            print($"1번째 코루틴 {i + 1}번째 수행됨.");
        }
        print("1번째 코루틴이 2번째 코루틴을 시작하고 대기함");
        yield return StartCoroutine(_2nd());
        print("1번째 코루틴 종료");
    }

    Coroutine _3rdCoroutine;

    private IEnumerator _2nd()
    {
        print("2번째 코루틴 시작됨");
        print("2번째 코루틴이 3번째 코루틴을 시작하고 대기함");
        _3rdCoroutine = StartCoroutine(_3rd());
        yield return _3rdCoroutine;
        //yield return StartCoroutine(_3rd());
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1f);
            print($"2번째 코루틴 {i + 1}번째 수행됨.");
        }
        print("2번째 코루틴 종료");
    }
    private IEnumerator _3rd()
    {
        print("3번째 코루틴 시작됨");
        for(int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1f);
            print($"3번째 코루틴 {i + 1}번째 수행됨.");
        }
        print("3번째 코루틴 종료");
    }

}
    