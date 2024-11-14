using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace MyProject
{
    public class GraphicRaycasterTest : MonoBehaviour, IPointerEnterHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {

        //드래그 시작
        public void OnBeginDrag(PointerEventData eventData)
        {
            EventSystemTextManager.instance.text.text = name;
        }


        //드래그 중
        public void OnDrag(PointerEventData eventData)
        {
            GetComponent<RectTransform>().anchoredPosition += eventData.delta;
            //이전 프레임과 현재 프레임의 포인터 위치 차이 (이동량)
        }


        //드래그 종료
        public void OnEndDrag(PointerEventData eventData)
        {
            EventSystemTextManager.instance.text.text = "Noting";
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            print("Mouse over");
        }
    }
}
