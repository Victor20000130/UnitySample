using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Context = UnityEngine.InputSystem.InputAction.CallbackContext;


namespace MyProject
{
    [RequireComponent(typeof(CharacterController), typeof(Animator), typeof(PlayerInput))]
    public class InputSystemMove : MonoBehaviour
    {
        private CharacterController charCtrl;
        private Animator animator;

        public float walkSpeed;
        public float runSpeed;

        Vector2 inputValue;

        public InputActionAsset controlDefine;

        InputAction moveAction;

        Vector2 velocity = Vector2.zero;
        Vector2 smoothValue;

        private void Awake()
        {
            charCtrl = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
            controlDefine = GetComponent<PlayerInput>().actions;
            moveAction = controlDefine.FindAction("Move");

        }

        private void OnEnable()
        {
            //moveAction.started -> XXDown
            moveAction.performed += OnMoveEvent;    // XX
            moveAction.canceled += OnMoveEvent;     //-> XXUp
        }

        private void OnDisable()
        {
            moveAction.performed -= OnMoveEvent;
            moveAction.canceled -= OnMoveEvent;
        }

        private void Update()
        {

            Vector3 inputMoveDir = new Vector3(inputValue.x, 0, inputValue.y) * walkSpeed;
            Vector3 actualMoveDir = transform.TransformDirection(inputMoveDir);

            charCtrl.Move(actualMoveDir * Time.deltaTime);
            smoothValue = Vector2.SmoothDamp(new Vector2(animator.GetFloat("Xdir"), animator.GetFloat("Ydir")), inputValue, ref velocity, 0.3f);
            animator.SetFloat("Xdir", smoothValue.x);
            animator.SetFloat("Ydir", smoothValue.y);
            animator.SetFloat("Speed", inputValue.magnitude);
        }

        public void OnMoveEvent(Context context)
        {
            print($"1. OnMoveEvent »£√‚ µ . context : {context.ReadValue<Vector2>()}");
            inputValue = context.ReadValue<Vector2>();
            //print($"2. OnMoveEvent »£√‚ µ . context : {context.ReadValue<Vector2>()}");
            //inputValue = Vector2.SmoothDamp(transform.position, inputValue, ref velocity, 0.1f);
            //print($"3. OnMoveEvent »£√‚ µ . context : {context.ReadValue<Vector2>()}");

        }

        private void OnMove(InputValue value)
        {
            //value.isPressed : true|false

            inputValue = value.Get<Vector2>();
            //print($"OnMove »£√‚/∆ƒ∂ÛπÃ≈Õ : {inputValue}");
        }
    }
}
