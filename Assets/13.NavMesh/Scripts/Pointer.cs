using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject
{
    public class Pointer : MonoBehaviour
    {

        public LayerMask targetLayer;
        private Renderer childrenderer;
        private Sequence jumpSequence;
        private Tweener jumpTween;
        private void Awake()
        {
            childrenderer = GetComponentInChildren<Renderer>();
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, 1000f, targetLayer))
                {
                    transform.position = hit.point;

                    //if (jumpTween != null)
                    //{
                    //    jumpTween.Complete();
                    //}
                    //childrenderer.enabled = true;
                    //jumpTween = transform.GetChild(0)
                    //    .DOPunchPosition(Vector3.up * 2f, 0.5f)
                    //    .OnComplete(() => childrenderer.enabled = false).SetEase(Ease.InElastic);



                }


            }
        }
    }
}
