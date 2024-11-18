using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject
{
	public class ExtenceMethod : MonoBehaviour
	{
		private void Start()
		{
			string[] a = new string[2];
			a = SplitClass.Split("¾È³ç ÇÏ¼¼¿ä", ' ');
			print(a[0]);
			print(a[1]);

		}


	}


	public static class SplitClass
	{

		public static string[] Split(this string str, char c)
		{
			string[] tmp = str.Split(new char[] { c });
			return tmp;
		}
	}

}
