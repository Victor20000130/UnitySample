using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject
{
	public class ParamsTest : MonoBehaviour
	{
		private new string[] name = { "김한결교강사님" ,"최현성", "최승현", "이지원", "유경동", "류지형", "장대훈", "김찬영" };
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