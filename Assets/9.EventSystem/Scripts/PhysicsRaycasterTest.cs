using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class ShapeData
{
    public enum Shape
    {
        Cube,
        Capsule,
        Sphere
    }
    public Shape shape;
    public float scale;
    public Color color;

}

namespace MyProject
{
    public class PhysicsRaycasterTest : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public ShapeData shapeData;

        public void OnPointerEnter(PointerEventData eventData)
        {
            EventSystemTextManager.instance.ShowTooltip(shapeData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            EventSystemTextManager.instance.HideTooltip();
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            EventSystemTextManager.instance.tooltip.GetComponent<RectTransform>().anchoredPosition
                = eventData.position;
            //eventData.Position : screen�� ���� �Ʒ� ���� (0,0)�� ��ǥ �������� ���콺 �������� ��ġ
        }

        private void Start()
        {
            GetComponentInParent<Renderer>().material.color = shapeData.color;
            transform.parent.localScale = Vector3.one * shapeData.scale;
        }
    }
}
