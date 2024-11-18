using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject
{
	public class ParamsTest : MonoBehaviour
	{
		private new string[] name = { "최현성", "최승현", "이지원", "유경동", "류지형", "장대훈", "김찬영" };
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
