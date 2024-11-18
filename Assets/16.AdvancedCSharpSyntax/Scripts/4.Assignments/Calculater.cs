using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyProject
{
    public delegate void Result(float result);
    public class Calculater : MonoBehaviour
    {
        public InputField inputNum1;
        public InputField inputNum2;
        public Button plus;
        public Button minus;
        public Button multiple;
        public Button devide;
        public Button equal;
        System.Action<float> cal;

        private void Awake()
        {

        }

        private void Start()
        {
            Result calc = Calc;
            //equal.onClick.AddListener(delegate { Calc(Plus(float.Parse(inputNum1.text), float.Parse(inputNum2.text))); });
            plus.onClick.AddListener(delegate { Plus(float.Parse(inputNum1.text), float.Parse(inputNum2.text)); });
            minus.onClick.AddListener(delegate { Minus(float.Parse(inputNum1.text), float.Parse(inputNum2.text)); });



        }

        private void Update()
        {

        }



        public void Calc(float result)
        {
            print(result);
        }

        private float Plus(float a, float b)
        {
            return a + b;
        }

        private float Minus(float a, float b)
        {
            return a - b;
        }

        private float Multiple(float a, float b)
        {
            return a * b;
        }
        private float Devide(float a, float b)
        {
            return a / b;
        }


    }
}
