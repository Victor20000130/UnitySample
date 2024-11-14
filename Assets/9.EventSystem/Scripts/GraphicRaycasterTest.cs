using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace MyProject
{
    public class GraphicRaycasterTest : MonoBehaviour, IPointerEnterHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {

        //�巡�� ����
        public void OnBeginDrag(PointerEventData eventData)
        {
            EventSystemTextManager.instance.text.text = name;
        }


        //�巡�� ��
        public void OnDrag(PointerEventData eventData)
        {
            GetComponent<RectTransform>().anchoredPosition += eventData.delta;
            //���� �����Ӱ� ���� �������� ������ ��ġ ���� (�̵���)
        }


        //�巡�� ����
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
