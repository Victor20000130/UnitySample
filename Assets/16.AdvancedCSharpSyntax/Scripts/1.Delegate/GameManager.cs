using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdvancedCSharp
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        private void Awake()
        {
            instance = this;
        }
    }
}

