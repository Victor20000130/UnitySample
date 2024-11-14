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


            float mouseX = Input.GetAxis("Mouse X"); //mouse�� ������ delta��
            float mouseY = Input.GetAxis("Mouse Y");

            //���콺�� �¿� �����ӿ� ���� ĳ������ Transform�� Rotate
            //transform.Rotate(0, mouseX * mouseSensitive * Time.deltaTime, 0);
            Rotate(transform, 0, mouseX * mouseSensitive * Time.deltaTime, 0);

            rigAngle -= mouseY * mouseSensitive * Time.deltaTime;

            //ī�޶�Rig�� X�� ������ ����
            rigAngle = Mathf.Clamp(rigAngle, -90f, 90f);

            //���ѵ� ������ŭ ī�޶�Rig�� X�� ������ ����
            cameraRig.localEulerAngles = new Vector3(rigAngle, 0, 0);


            //���콺�� ���� �����ӿ� ���� ī�޶� Rig�� Transform�� Rotate
            //cameraRig.Rotate(-mouseY * mouseSensitive * Time.deltaTime, 0, 0);
            //Rotate(cameraRig, -mouseY * mouseSensitive * Time.deltaTime, 0, 0);
        }

        private void Rotate(Transform t, float x, float y, float z)
        {
            t.Rotate(x, y, z);
        }
    }
}
