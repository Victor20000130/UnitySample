using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject
{
	public class ParamsTest : MonoBehaviour
	{
		private new string[] name = { "���Ѱᱳ�����" ,"������", "�ֽ���", "������", "���浿", "������", "�����", "������" };
        private string temp;
        private void Start()
		{
			PrintLinesOne(name);
			PrintLinesTwo(name);
		}

		private void PrintLinesOne(params string[] strings)
		{
			foreach (string s in strings)
			{
				print(s);
			}
		}

		private void PrintLinesTwo(params string[] strings)
		{
			foreach(string s in strings)
			{
				temp += s.Append("\n");
            }
			print(temp);
		}
	}
}