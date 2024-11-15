using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Context = UnityEngine.InputSystem.InputAction.CallbackContext;
namespace MyProject
{
    [RequireComponent(typeof(CharacterController), typeof(Animator), typeof(PlayerInput))]

    public class InputSystemLook : MonoBehaviour
    {
        public Transform cameraRig;
        public float mouseSensivity;
        private float rigAngle = 0f;

        public InputActionAsset controlDefine;
        InputAction lookAction;

        private void Awake()
        {
            controlDefine = GetComponent<PlayerInput>().actions;
            lookAction = controlDefine.FindAction("Look");
        }
        private void OnEnable()
        {
            lookAction.performed += OnLookEvent;
            lookAction.canceled += OnLookEvent;
        }
        private void OnDisable()
        {
            lookAction.performed -= OnLookEvent;
            lookAction.canceled -= OnLookEvent;
        }
        public void OnLookEvent(Context context)
        {
            if (false == SimpleMouseControl.isFocusing) return;
            //print($"OnLockEvent 호출 됨. context : {context.ReadValue<Vector2>()}");
            Look(context.ReadValue<Vector2>());
        }

        private void OnLook(InputValue value)
        {
            //print($"OnLook 호출. 값 : {value.Get<Vector2>()}");
            if (false == SimpleMouseControl.isFocusing) return;
            //esc 누르거나 포커스 벗어나면 마우스 인식 안함

            Vector2 mouseDelta = value.Get<Vector2>();
            Look(mouseDelta);


        }

        private void Look(Vector2 mouseDelta)
        {
            transform.Rotate(0f, mouseDelta.x * mouseSensivity * Time.deltaTime, 0f);
            rigAngle -= mouseDelta.y * mouseSensivity * Time.deltaTime;

            rigAngle = Mathf.Clamp(rigAngle, -90f, 90f);
            cameraRig.localEulerAngles = new Vector3(rigAngle, 0, 0);
        }
    }
}
