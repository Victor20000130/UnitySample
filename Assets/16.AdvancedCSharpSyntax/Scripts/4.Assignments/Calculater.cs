using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyProject
{
	public delegate float Result(float a, float b);
	public class Calculater : MonoBehaviour
	{
		public InputField inputNum1;
		public InputField inputNum2;
		public Button plus;
		public Button minus;
		public Button multiple;
		public Button devide;
		public Button equal;
		Result calc;
		private float val;

		private void Start()
		{
			plus.onClick.AddListener(() => { calc += Plus; });
			minus.onClick.AddListener(() => { calc += Minus; });
			multiple.onClick.AddListener(() => { calc += Multiple; });
			devide.onClick.AddListener(() => { calc += Devide; });
			equal.onClick.AddListener(() =>
			{
				Calc(calc.Invoke(float.Parse(inputNum1.text), float.Parse(inputNum2.text)));
			});
		}

		private void Calc(float res) => print(res);

		private float Plus(float a, float b) => a + b;

		private float Minus(float a, float b) => a - b;

		private float Multiple(float a, float b) => a * b;

		private float Devide(float a, float b) => a / b;
	}
}
