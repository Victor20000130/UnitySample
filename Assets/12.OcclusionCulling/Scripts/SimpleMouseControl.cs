using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject
{
    public class SimpleMouseControl : MonoBehaviour
    {
        private void Start()
        {
            //마우스 커서 화면에 잠금
            //Locked : 화면 중앙에 잠김
            //Confined : 화면 테두리 안에 갇힘
            //None : 안잠금
            //Cursor.lockState = CursorLockMode.Locked;
            //커서 보이는 여부. Editor의 경우에 따로 설정 안해도 Esc 키를 누르면 마우스가 보임
            //Cursor.visible = false;
            OnApplicationFocus(true);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnApplicationFocus(false);
            }
            else if (Input.anyKeyDown)
            {
                OnApplicationFocus(true);
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
