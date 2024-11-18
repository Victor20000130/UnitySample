using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable IDE0051

namespace MyProject
{
    //Delegate 키워드 1 : 대리자. 함수의 이름을 대체해준다.
    //내부적으로는 일종의 Class처럼 동작.
    //delegate의 선언 형태 : 접근제한자 delegate [반환형] 이름(파라미터);
    //delegate의 반환은 맨 마지막에 등록한 함수의 리턴을 반환해줌
    public delegate void SomeMethod(int a); //return이 없는 함수(Method)
    public delegate int SomeFunction(int a, int b);


    //delegate 키워드2 : 무명 메서드 선언으로 활용.
    public class DelegateTest : MonoBehaviour
    {
        public Text text;

        private void Start()
        {
            SomeMethod myMethod = PrintInt;
            myMethod(1); // Console : 1 출력
            myMethod += CreateInt;
            myMethod(2); // Console : 2 출력, 2라는 이름의 게임 오브젝트 생성
            myMethod -= PrintInt;
            myMethod.Invoke(3); //3 이라는 이름의 게임 오브젝트 생성
            myMethod -= CreateInt;
            myMethod?.Invoke(4); // myMethod가 null이면 그냥 호출 안함

            if (myMethod != null) myMethod.Invoke(4);

            SomeMethod delegateIsClass = new SomeMethod(PrintInt);
            delegateIsClass(5); // Console : 5 출력

            SomeFunction iDontKonw = Plus;
            int firstReturn = iDontKonw(1, 2);
            print(firstReturn);
            iDontKonw += Multiple;
            int secondReturn = iDontKonw(1, 2);
            print(secondReturn);
            //iDontKonw += PlusFloat; //에러

            //delegate의 무명 메서드 활용
            SomeMethod someUnnamedMethod = delegate (int a) { text.text = a.ToString(); };

            //1차 간소화 : delegate 키워드 대신 => 연산자로 대체
            someUnnamedMethod += (int a) => { print(a); };

            //2차 간소화 : 파라미터 데이터 타입을 생략 가능.
            someUnnamedMethod += (b) =>
            {
                print(b);
                text.text = b.ToString();
            };

            //3차 간소화 : 함수 내용이 1줄(세미콜론;이 1개만 사용)일 경우, 중괄호 생략 가능.
            someUnnamedMethod += (c) => print(c);

            //함수 1줄 간소화의 경우 return 키워드까지 생략 가능.
            SomeFunction someUnnamedFunction = (someIntA, someIntB) => Plus(someIntA, someIntB);
            someUnnamedMethod(4);

            myMethod += someUnnamedMethod;
            myMethod -= someUnnamedMethod;

            //무명메서드의 단점 : 해당 메서드를 추후에 다시 참조활 수 없다. 선언 시점에서만 참조가 가능

            //string stringA = new string("");
            //string stringB = "";

            //.netFramework 내장 delegate

            //1. 리턴이 없는 함수(Method) : Action
            System.Action nonParamMethod = () => { };
            System.Action<int> intParamMethod = (int a) => { };
            System.Action<string> stringParamMethod = (b) => { };
            //2. 리턴이 있는 함수(Function) : Func
            System.Func<int> nonParamFunc = () => { return 3; };
            //System.Func<int> nonParamFunc = () => 3; //이렇게도 쓸 수 있지만 가독성 떨어지기 때문에 주의
            System.Func<int, string> intParamFunc = (int a) => { return a.ToString(); };
            //3. 조건 검사를 위해 무조건 bool 리턴을 가진 함수 : Predicate
            System.Predicate<int> isSame = (a) => { return a == 1; };
            //그 외
            System.Comparison<Color> compare = (a, b) => { return (int)(a.a - a.a); };


        }

        private void PrintInt(int a) => print(a);


        private void CreateInt(int a)
        {
            new GameObject().name = a.ToString();
        }

        private int Plus(int a, int b)
        {
            print("Plus 호출");
            return a + b;
        }

        private int Multiple(int c, int d)
        {
            print("Multiple 호출");
            return c * d;
        }

        private float PlusFloat(float a, float b)
        {
            return a + b;
        }



    }
}
