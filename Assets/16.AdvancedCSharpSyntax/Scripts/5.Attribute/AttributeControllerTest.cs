using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyProject
{
	public class AttributeControllerTest : MonoBehaviour
	{
		//[Color(0, 1, 0, 1)]
		//public Renderer rend;
		[Size(3, 3, 3)]
		public Transform cube;

		//[SerializeField, Color(r: 1, b: 0.5f), Size(150, 150)]
		//private Graphic graphic;
		[Color(1, 1, 1, 1), Size(300, 300)]
		public RectTransform image;


		//[Color()]
		//public float notRendererOrGraphic;

		[Size(3, 3, 3)]
		public char ch;

	}
}
