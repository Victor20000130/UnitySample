using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class BuiltinClassesTest : MonoBehaviour
{

    //유니티 엔진에서 제공하는 라이브러리에 내장된 클래스를 활용.
    //Debug : 디버깅에 사용되는 기능을 제공하는 클래스.

    void Start()
    {
        //Debug.Log($"Log{1}");
        //Debug.LogWarning("");
        //Debug.LogError("");
        //Debug.LogFormat("{0}, {1}", 3, 5.0);//xxFormat으로 끝나는 함수들 : 파라미터를 포맷에 따라 치환하는 문자열
        //Debug.DrawLine(Vector3.zero, new Vector3(0, 3), Color.magenta, 5f); : 지정좌표부터 목표좌표까지 선을 그린다.
        //Debug.DrawRay(Vector3.zero, new Vector3(0, 5), Color.magenta, 10f); : 세계좌표에서 시작점까지 선을 그린다

        //Mathf : UnityEngine에서 제공하는 다양한 수학 연산 함수가 포함된 클래스.
        //Mathf.Abs() : 절대값 반환
        float a = -0.3f;
        a = Mathf.Abs(a);
        print(a);
        a = Mathf.Abs(+0.3f);
        print(a);

        //근사값 비교. 실수의 근사값 비교. 정확히 같은지를 검사할 수 없으므로 근사값을 검사하기 위해 사용함.
        print(1.1f + 0.1f == 1.2f);
        print(Mathf.Approximately(1.1f + 0.1f, 1.2f));

        //Mathf.Lerp(a, b, t) : 선형 보간([L]inear Int[erp]olation)
        //a값과 b 값 사이의 t의 비율만큼에 위치하는 값.(0<t<1)
        print(Mathf.Lerp(-1f, 1f, 0.5f));
        //Lerp(선형 보간)함수는 Color, Vector(2, 3, 4), Material, Quaternion 등의 클래스에도 존재함.
        Mathf.InverseLerp(0, 0, 0); // Lerp의 a, b 파라미터가 반대

        //Mathf.Ceil, Floor, Round : 올림, 내림, 반올림

        float value = 5.4f;

        float ceil = Mathf.Ceil(value);
        float floor = Mathf.Floor(value);
        float round = Mathf.Round(value);
        print($"Ceil : {ceil}, Floor : {floor}, Round : {round}");

        //print(Mathf.Sign(value)); // 부호
        //print(Mathf.Sin(value)); // 삼각함수 사인
        //print(Mathf.Pow(value, 1.2f)); // 거듭제곱
        //print($"Deg2Rad * value : {Mathf.Deg2Rad * value}");
        //print($"Rad2Deg * value : {Mathf.Rad2Deg * value}");

        //Random : 난수를 생성하는 클래스.
        //System.Random r = new System.Random(); // .net 프레임워크에서 제공하는 랜덤
        //random.Next();

        //int를 반환하는 Range함수는 최대값은 제외하고 반환
        int intRandom = Random.Range(-1, 1); // -1, 0 만 리턴

        //float을 반환하는 Range함수는 최대값과 같다고 간주되는 값이 반환될 수도 있음
        float floatRandom = Random.Range(-1f, 1f); // -1.00..1 ~ 0.99... 리턴 Max값도 리턴될 수 있음

        float randomValue = Random.value; // == Random.Range(0f,1f); 백분율 확률을 편하게 얻기 위해 사용

        Vector3 randomPosition = Random.insideUnitSphere * 5f; // * 5f 는 사이즈를 구하는것
        //Vector3(-1~1, -1~1, -1~1); 랜덤한 위치를 뽑고 싶을 때 효율적.

        Vector3 randomDirection = Random.onUnitSphere;
        // 랜덤한 Vector3가 오는데, 길이가 항상 1. 랜덤한 "방향"을 뽑고 싶을 때 효율적.

        Vector2 randomPosition2D = Random.insideUnitCircle;
        // 2D용 Random Vector

        //Random.rotation;

        Random.InitState(11234); // 난수의 시드값 초기화.
        //연산 부하가 많이 걸리는 함수이므로, 제한적으로 (씬 로딩 초기때쯤에나) 사용할 것.

    }

    //Gizmos : Scene창에서만 볼 수 있는 "기즈모"를 그리는 클래스.(Debug.DrawXX의 확장기능처럼)

    void Update()
    {
        Gizmos.DrawCube(Vector3.zero, Vector3.one); // <<--의미 없음
    }

    
    //Gizmos 클래스는 OnDrawGizmos, OnDrawGizmosSelected, OnSceneGUI등 Scene창과 에디터에서만
    //활성화 되는 메세지 함수에서만 유효하게 기능함.
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
