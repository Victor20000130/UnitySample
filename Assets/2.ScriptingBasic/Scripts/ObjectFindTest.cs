using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFindTest : MonoBehaviour
{
    //게임이 시작되기 전 씬에서 참조할 수 있는 오브젝트는 Inspector에서 할당하여 참조할 수 있음.
    public GameObject target;
    //그런데 게임이 시작되기 전에 참조할 수 없거나, Inspector에서 값을 할당할 수 없는 객체는?
    private GameObject privateTarget;
    private GameObject findedTarget;
    private GameObject newTarget;
    private GameObject namedNewTarget;
    private GameObject componentAttachedTarget;

    private void Start()
    {
        //privateTarget을 찾는다
        //1. 전체 씬에서 이름으로 타겟을 찾는다.
        privateTarget = GameObject.Find("PrivateTarget");
        //이 방법은 씬에 오브젝트가 많을수록 부하가 크게 걸림.
        //씬에 올라와 있는 모든 오브젝트의 이름을 검사하기 때문에
        //같은 오브젝트가 여러개 있을 경우 어떤 오브젝트가 탐색될지 확신한 수 없음.
        //이런 이유로 Start() 함수에서만 제한적으로 쓰임.

        //2. 전체 씬에서 특정 컴포넌트를 가지고 있는 객체를 찾는다.
        //findedTarget = (FindObjectOfType(typeof(FindMe)) as Component).gameObject;
        findedTarget = FindObjectOfType<FindMe>().gameObject;
        //print(findedTarget.name);
        
        //3. 아예 객체를 직저 생성하고 해당 객체의 참조를 유지해도 된다.
        newTarget = new GameObject();
        namedNewTarget = new GameObject("New Target");
        componentAttachedTarget = new GameObject("Component Attached GameObject", typeof(FindMe), typeof(SpriteRenderer));

        //4. Destroy함수를 통해 객체를 아예 입도 뻥긋 못하게 도륙을 내버릴 수도 있다.
        Destroy(privateTarget, 2f);
        


    }
}
