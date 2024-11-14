using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MyProject
{
    public class EventTriggerTest : MonoBehaviour
    {
        public void OnClick()
        {
            print("click!");
        }

        public void OnEnter()
        {
            print("enter!");
        }
        public void OnExit()
        {
            print("exit!");
        }

        public void OnAnyEvent(BaseEventData eventData)
        {
            print($"some event called, type : {(eventData as PointerEventData).position}");
        }
    }
}
