using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGUIButton : MonoBehaviour
{
    //Button 컴포넌트의 OnClick() 이벤트에 할당하여 해당 버튼이 클릭될 때마다 호출 되도록
    //"유니티 엔진이" Inspector에 할당된 대로 의존성을 주입해준다.
    //Inspector에서 해당 함수를 참조하려면 접근 지정자가 public이어야 함.
    //이미 참조된 후에 private로 바꾸면 그대로 유지가 되긴 함. 하지만 Inspector상에서는 찾을 수 없음.
    public void ButtonClick() //이 함수는 버튼이 클릭될 때 호출.
    {
        print("버튼 클릭됨.");
    }
    public void ButtonClickWithParam(string param)
    {
        print($"버튼 클릭됨. 파라미터 : {param}");
    }

    public void ButtonClickWithFloatParam(float param)
    {
        print($"버튼 클릭됨. 파라미터 : {param}");
    }
    public void ButtonClickWithBoolParam(bool param)
    {
        print($"버튼 클릭됨. 파라미터 : {param}");

    }
}
