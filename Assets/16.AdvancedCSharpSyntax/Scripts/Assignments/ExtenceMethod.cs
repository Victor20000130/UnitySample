using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;

namespace MyProject
{
	public class ExtenceMethod : MonoBehaviour
	{

		private void Start()
		{
			print(ExtensionClass.Split("�ȳ� �ϼ���", ' ')[0]);
			print(ExtensionClass.Split("�ȳ� �ϼ���", ' ')[1]);
			print(ExtensionClass.ToLower("ABCDEFG"));
			print("abcdefg".ToUpper());
			string upperStr = "abcdefg".ToUpper();
			string str = "�ȳ� �ϼ���".Split(' ')[0];
			"ABCDE".ToLower();
			"abcde".ToUpper();
		}
	}

	public static class ExtensionClass
	{
		public static string[] Split(this string str, char inStr)
		{
			List<string> list = new List<string>();
			string temp = null;
			for (int i = 0; i < str.Length; i++)
			{
				temp += str[i];
				if (str[i] == inStr)
				{
					list.Add(temp.Substring(0, i));
				}
			}
			list.Add(str.Substring(str.IndexOf(' ') + 1).Trim());
			return list.ToArray();
		}
		public static string ToLower(this string str)
		{
			return str.ToLower();
		}

		public static string ToUpper(this string str)
		{

			return str.ToUpper();
		}

	}
}