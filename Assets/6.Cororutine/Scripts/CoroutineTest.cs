using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    
    MeshRenderer mr;
    
    public Material woodMaterial;
    public Material redMaterial;

    public Material stoneMaterial;

    public Transform transformTest;

    private Coroutine mat_ChangeCoroutine;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        stoneMaterial = mr.material;
    }

    void Start()
    {
        //정확히 3초 후에 MeshRenderer의 Material을 woodMaterial로 교체하고 싶어요.
        var enumerator = StringEnumerator();
        //enumerator.MoveNext();
        //print(enumerator.Current);
        //enumerator.MoveNext();
        //print(enumerator.Current);
        //보통 아래처럼 사용함.
        //while (enumerator.MoveNext())
        //{
        //    print(enumerator.Current);
        //}

        //List<int> intList = new List<int>() { 1, 2, 3 };
        //foreach (int someInt in intList) 
        //{
        //    print(someInt);
        //}

        //IEnumerator를 상속하고 있는 애들은 다 사용이 가능함.
        //foreach (Transform someTransform in transformTest)
        //{
        //    print(someTransform.name);
        //}


        //StartCoroutine("MaterialChange");//이거 쓰면 하수
        //코루틴은 코루틴을 반환할 수 있다.
        //코루틴만들어서 매개변수로 올려서 응용할 수 있다.
        mat_ChangeCoroutine = StartCoroutine(MaterialChange(redMaterial, 1f));//고수
        

    }


    void Update()
    {
        //if(Time.time > 3f)
        //{
        //    mr.material = woodMaterial;
        //}

        if(Input.GetButtonDown("Jump"))
        {
            mr.material = stoneMaterial;
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            print("코루틴 스탑");
            //StopCoroutine("MaterialChange");//하수
            StopCoroutine(mat_ChangeCoroutine);//고수
        }
    }

    private IEnumerator<string> StringEnumerator()
    {
        //IEnumerator를 반환하는 함수는
        //yield return 키워드를 통해
        //값을 순차적으로 반환할 수 있음.
        yield return "a";
        yield return "b";
        yield return "c";
    }

    private IEnumerator MaterialChange(Material mat, float interval)
    {
        while (true)
        {
            //코루틴이 interval초 대기 합니다.
            yield return new WaitForSeconds(interval);
            mr.material = mat;
        }
    }

}
