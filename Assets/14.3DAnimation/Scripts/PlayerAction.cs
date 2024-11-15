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
                //재장전
                rig.weight = 0f;
                isReloading = true;
                animator.SetTrigger("Reload");
            }
        }

        public void OnReloadEnd()
        {   //외부에서 제작된 FBX내장 애니메이션에도 이벤트를 추가할 수 있다.
            //다만, Animation Rig는 이벤트로 weight를 조절할 수 없음
            //애니메이션 수행 도중에 weight값 조정 불가 | rig.weight 조절불가
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
