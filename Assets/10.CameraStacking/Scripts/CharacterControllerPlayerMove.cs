using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject
{
    public class CharacterControllerPlayerMove : MonoBehaviour
    {
        public float moveSpeed;
        public float turnSpeed;
        private Vector3 moveDir;
        private CharacterController cc;
        ControllerColliderHit cch;
        private float gravity = -0.5f;
        private void Awake()
        {
            cc = GetComponent<CharacterController>();
        }

        private void Start()
        {

        }

        private void Update()
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");

            if (cc.isGrounded == false)
            {
                moveDir.y += gravity * Time.fixedDeltaTime;
            }

            Move(inputY * Time.fixedDeltaTime * moveSpeed);
            Turn(inputX * Time.fixedDeltaTime * turnSpeed);

        }

        private void Move(float speed)
        {
            cc.Move(moveDir + transform.forward * speed);
        }

        private void Turn(float angle)
        {
            transform.rotation = transform.rotation * Quaternion.Euler(0, angle, 0);
        }


        //private void OnCollisionEnter(Collision collision)
        //{

        //    print($"Hi {collision.collider.gameObject.name}");

        //}
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            print(hit.collider.gameObject.name);

            print($"Hi {hit.collider.excludeLayers}");
        }
    }
}
