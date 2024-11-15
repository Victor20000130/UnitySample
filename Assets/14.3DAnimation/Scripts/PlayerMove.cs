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
        private Camera cam;
        #endregion
        #region Public Fields
        public float walkSpeed;
        public float runSpeed;
        public TwoBoneIKConstraint leftHand;
        public MultiAimConstraint rightHand;
        #endregion
        #region Private Fields
        private float currentSpeed;
        #endregion



        private void Awake()
        {

            cam = GetComponentInChildren<Camera>();
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
            //Fire();
            ////Reloading();
            //Grenade();
            //HandsReplace();
            //ZoomInOut();





        }

        private void HandsReplace()
        {
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

        private void Grenade()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                animator.SetTrigger("Grenade");
            }
        }

        private void Reloading()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                animator.SetTrigger("Reloading");
            }
        }

        private void Fire()
        {
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Fire");
            }
        }

        private void ZoomInOut()
        {
            if (Input.GetMouseButton(1))
            {
                cam.fieldOfView = 10;
            }
            if (Input.GetMouseButtonUp(1))
            {
                cam.fieldOfView = 60;
            }
        }


        private void Move()
        {
            Vector3 inputValue = Vector3.zero;
            inputValue.x = Input.GetAxis("Horizontal");
            inputValue.z = Input.GetAxis("Vertical");

            inputValue = Vector3.ClampMagnitude(inputValue, 1);

            float runValue = Input.GetAxis("Fire3");

            //              �� ĳ���Ͱ� �Ȱ� ���� ���� �ӵ�     +  �� ĳ���Ͱ� �ٰ� ���� ���� �ӵ�
            currentSpeed = (inputValue.magnitude * walkSpeed) + (runValue * (runSpeed - walkSpeed));

            Vector3 inputMoveDir = inputValue * currentSpeed;

            //                               ���� ����� ���� ������ ��ġ�ϵ��� ��ȯ��
            Vector3 actualMoveDir = transform.TransformDirection(inputMoveDir);

            charCtrl.Move(actualMoveDir * Time.deltaTime);

            animator.SetFloat("Xdir", inputValue.x);
            animator.SetFloat("Ydir", inputValue.z);

            animator.SetFloat("Speed", inputValue.magnitude + runValue);

        }

    }
}
