using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject
{
	public class ParamsTest : MonoBehaviour
	{
		private new string[] name = { "������", "�ֽ���", "������", "���浿", "������", "�����", "������" };
		private void Start()
		{
			PrintLines(name);
		}

		private void PrintLines(params string[] strings)
		{
			foreach (string s in strings)
			{
				print(s);
			}
		}
	}
}
