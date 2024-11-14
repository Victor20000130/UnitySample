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
                //ScreenPointToRay : �ش� ī�޶� �������� ��ũ���� ���콺 ��ġ���� ī�޶� ���� �������� ���̸� ����.
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                //Physics.Raycast �Լ� ȣ���, Layer Mask�� �Ķ���ͷ� ������� ������
                //�ڵ����� Ignore Raycast ���̾�� ������.
                if (Physics.Raycast(ray, out RaycastHit hit, 1000f,
                    1 << LayerMask.NameToLayer("Ignore Physics")))
                {
                    hit.collider.GetComponentInParent<Renderer>().material.color = Color.red;
                }
            }
        }

    }
}