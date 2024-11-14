using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject
{
    public class SimpleMouseControl : MonoBehaviour
    {
        private void Start()
        {
            //���콺 Ŀ�� ȭ�鿡 ���
            //Locked : ȭ�� �߾ӿ� ���
            //Confined : ȭ�� �׵θ� �ȿ� ����
            //None : �����
            //Cursor.lockState = CursorLockMode.Locked;
            //Ŀ�� ���̴� ����. Editor�� ��쿡 ���� ���� ���ص� Esc Ű�� ������ ���콺�� ����
            //Cursor.visible = false;
            OnApplicationFocus(true);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isFocusing = false;
            }
        }
        public static bool isFocusing = true;

        private void OnApplicationFocus(bool focus)
        {
            isFocusing = focus;

            if (isFocusing)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

        }
    }
}