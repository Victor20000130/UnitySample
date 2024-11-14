using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MyProject
{
    public abstract class EventsManager : MonoBehaviour
    {
        public virtual void OnEnter()
        {
            print($"Hi! I'm {gameObject.name}!");
        }


    }
}
