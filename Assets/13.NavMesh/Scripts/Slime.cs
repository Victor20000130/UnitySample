using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyProject
{
    public class Slime : MonoBehaviour
    {
        public Transform idleTarget1;
        public Transform idleTarger2;
        private Transform currentTarget;
        private NavMeshAgent agent;
        private Vector3 home;
        private Vector3 offset = new Vector3(10, 2, 10);
        public LayerMask targetLayer;
        private enum State
        {
            Idle,
            Chase,
            Attack,
            Return
        }
        private State state;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }
        private void Start()
        {
            currentTarget = idleTarget1;
            home = transform.position;
            state = State.Idle;
        }
        private void Update()
        {
            switch (state)
            {
                case State.Idle:
                    IdleState();
                    break;
                case State.Chase:
                    ChaseState();
                    break;
                case State.Attack:

                    break;
                case State.Return:
                    ReturnState();
                    break;
            }
        }

        public void IdleState()
        {
            agent.SetDestination(currentTarget.position);
            if ((transform.position - idleTarget1.position).magnitude <= 0.2f)
            {
                currentTarget = idleTarger2;
            }
            else if ((transform.position - idleTarger2.position).magnitude <= 0.2f)
            {
                currentTarget = idleTarget1;
            }

            Collider[] colls = Physics.OverlapBox(transform.position, offset * 0.5f, Quaternion.identity, targetLayer);
            if (colls.Length != 0)
            {
                currentTarget = colls[0].transform;
                state = State.Chase;
            }

        }


        public void ChaseState()
        {
            Debug.Log("Chase");
            agent.SetDestination(currentTarget.position);
            Collider[] colls = Physics.OverlapBox(transform.position, offset * 0.5f, Quaternion.identity, targetLayer);
            if (colls.Length == 0)
            {
                state = State.Return;
            }
        }
        public void AttackState()
        {

        }
        public void ReturnState()
        {
            Debug.Log("Return");
            agent.SetDestination(home);
            if ((transform.position - home).magnitude <= 0.2f)
            {
                Debug.Log("State = Idle");
                currentTarget = idleTarget1;
                state = State.Idle;
            }
        }
        void OnDrawGizmos()
        {
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(Vector3.zero, offset);
        }
    }
}
