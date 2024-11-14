using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


namespace MyProject
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentController : MonoBehaviour
    {
        public Transform pointer;
        private NavMeshAgent agent;
        public bool isStop;

        public float hp;
        private float maxHp;
        public Image hpBar;
        private float hpAmount { get { return hp / maxHp; } }

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            hpBar.fillAmount = hpAmount;

            //AI에게 특정 지점으로 이동하도록 하는 함수
            agent.SetDestination(pointer.position);

            agent.isStopped = isStop;
        }

        public void TakeDamage(float damage)
        {
            hp -= damage;
        }
    }
}
