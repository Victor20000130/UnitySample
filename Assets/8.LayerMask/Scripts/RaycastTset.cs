using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject
{
    public class RaycastTset : MonoBehaviour
    {
        //0000 0000 : Nothing
        //0000 0001 : Default        1 << 0
        //0000 0010 : TransparentFX  1 << 1
        //0000 1000 : Ignore Physics 1 << 3
        //0000 1001 : Default, Ignore Physics : 9
        public LayerMask customMask;



        private void Start()
        {
            print($"Default Layer : {LayerMask.NameToLayer("Default")}");
            print($"TransparentFX Layer : {LayerMask.NameToLayer("TransparentFX")}");
            print($"Ignore Physics Layer : {LayerMask.NameToLayer("Ignore Physics")}");
            print($"Custom Layer Mask : {customMask.value}");
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                //ScreenPointToRay : 해당 카메라 시점에서 스크린의 마우스 위치에서 카메라가 보는 방향으로 레이를 생성.
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                //Physics.Raycast 함수 호출시, Layer Mask를 파라미터로 명시하지 않으면
                //자동으로 Ignore Raycast 레이어는 무시함.
                if (Physics.Raycast(ray, out RaycastHit hit, 1000f,
                    1 << LayerMask.NameToLayer("Ignore Physics")))
                {
                    hit.collider.GetComponentInParent<Renderer>().material.color = Color.red;
                }
            }
        }

    }
}