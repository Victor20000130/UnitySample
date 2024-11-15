using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace MyProject
{
    [RequireComponent(typeof(Animator), typeof(RigBuilder))]
    public class PlayerAction : MonoBehaviour
    {
        private Animator animator;
        private Rig rig;
        private WaitUntil untilReload;
        public AnimationClip reloadClip;
        private void Awake()
        {
            animator = GetComponent<Animator>();
            rig = GetComponent<RigBuilder>().layers[0].rig;
        }

        private void Start()
        {
            untilReload = new WaitUntil(() => isReloading);
            StartCoroutine(ReloadCoroutine());
        }

        private bool isReloading = false;
        private void Update()
        {
            if (false == isReloading && Input.GetKeyDown(KeyCode.R))
            {
                //������
                rig.weight = 0f;
                isReloading = true;
                animator.SetTrigger("Reload");
            }
        }

        public void OnReloadEnd()
        {   //�ܺο��� ���۵� FBX���� �ִϸ��̼ǿ��� �̺�Ʈ�� �߰��� �� �ִ�.
            //�ٸ�, Animation Rig�� �̺�Ʈ�� weight�� ������ �� ����
            //�ִϸ��̼� ���� ���߿� weight�� ���� �Ұ� | rig.weight �����Ұ�
            //isReloading = false;
        }

        IEnumerator ReloadCoroutine()
        {
            while (true)
            {
                yield return untilReload;
                yield return new WaitForSeconds(reloadClip.length);
                isReloading = false;
                rig.weight = 1f;
            }
        }
    }
}
