using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace MyProject
{
    public class PlayerLook : MonoBehaviour
    {
        public Transform cameraRig;

        public float mouseSensitive;

        private float rigAngle = 0f;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            Look();
        }


        private void Look()
        {
            if (false == SimpleMouseControl.isFocusing) return;


            float mouseX = Input.GetAxis("Mouse X"); //mouse가 움직인 delta값
            float mouseY = Input.GetAxis("Mouse Y");

            //마우스의 좌우 움직임에 맞춰 캐릭터의 Transform을 Rotate
            //transform.Rotate(0, mouseX * mouseSensitive * Time.deltaTime, 0);
            Rotate(transform, 0, mouseX * mouseSensitive * Time.deltaTime, 0);

            rigAngle -= mouseY * mouseSensitive * Time.deltaTime;

            //카메라Rig의 X축 각도를 제한
            rigAngle = Mathf.Clamp(rigAngle, -90f, 90f);

            //제한된 각도만큼 카메라Rig의 X축 각도를 변경
            cameraRig.localEulerAngles = new Vector3(rigAngle, 0, 0);


            //마우스의 상하 움직임에 맞춰 카메라 Rig의 Transform을 Rotate
            //cameraRig.Rotate(-mouseY * mouseSensitive * Time.deltaTime, 0, 0);
            //Rotate(cameraRig, -mouseY * mouseSensitive * Time.deltaTime, 0, 0);
        }

        private void Rotate(Transform t, float x, float y, float z)
        {
            t.Rotate(x, y, z);
        }
    }
}
