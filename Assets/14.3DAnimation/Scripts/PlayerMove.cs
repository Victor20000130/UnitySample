using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;



namespace MyProject
{
    [RequireComponent(typeof(CharacterController), typeof(Animator))]
    public class PlayerMove : MonoBehaviour
    {

        #region Private Components
        private CharacterController charCtrl;
        private Animator animator;
        #endregion
        #region Public Fields
        public float walkSpeed;
        public float runSpeed;
        #endregion
        #region Private Fields
        private float currentSpeed;
        #endregion

        public TwoBoneIKConstraint leftHand;
        public MultiAimConstraint rightHand;

        private void Awake()
        {

            charCtrl = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
        }
        private void Start()
        {
            animator.SetLayerWeight(1, 1);
        }
        private void Update()
        {
            Move();

            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Fire");
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                animator.SetTrigger("Reloading");
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                animator.SetTrigger("Grenade");
            }
            Debug.Log($"On Update Idle? : {animator.GetCurrentAnimatorStateInfo(1).IsName("Idle")}");
            if (animator.GetCurrentAnimatorStateInfo(1).IsName("Idle") || animator.GetCurrentAnimatorStateInfo(1).IsName("Fire"))
            {
                leftHand.weight = 1;
                rightHand.weight = 1;
            }
            else
            {
                leftHand.weight = 0;
                rightHand.weight = 0;
            }

        }


        private void Anim()
        {

        }


        private void Move()
        {
            Vector3 inputValue = Vector3.zero;
            inputValue.x = Input.GetAxis("Horizontal");
            inputValue.z = Input.GetAxis("Vertical");

            inputValue = Vector3.ClampMagnitude(inputValue, 1);

            float runValue = Input.GetAxis("Fire3");

            //              내 캐릭터가 걷고 있을 때의 속도     +  내 캐릭터가 뛰고 있을 때의 속도
            currentSpeed = (inputValue.magnitude * walkSpeed) + (runValue * (runSpeed - walkSpeed));

            Vector3 inputMoveDir = inputValue * currentSpeed;

            //                               로컬 방향과 월드 방향을 일치하도록 반환함
            Vector3 actualMoveDir = transform.TransformDirection(inputMoveDir);

            charCtrl.Move(actualMoveDir * Time.deltaTime);

            animator.SetFloat("Xdir", inputValue.x);
            animator.SetFloat("Ydir", inputValue.z);

            animator.SetFloat("Speed", inputValue.magnitude + runValue);

        }

    }
}
