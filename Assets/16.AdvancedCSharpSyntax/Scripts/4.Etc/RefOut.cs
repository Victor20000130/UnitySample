using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject
{
	public class RefOut : MonoBehaviour
	{
		//ref 키워드 : Value 타입(enum, struct, literal) 데이터를 파라미터를 통해 함수에 전달할 경우.
		//메모리 값을 복사하여 전달하는데, 이를 포인터 로 대체하는 파라미터를 선언할 경우에 사용.

		private void Start()
		{
			int a = 10;
			int b = 20;
			print($"a : {a}, b : {b}");
			Swap(ref a, ref b);
			print($"a : {a}, b : {b}");

			GameObject obj1 = new GameObject("No.1");
			obj1.transform.position = new Vector3(1, 0, 0);
			GameObject obj2 = new GameObject("No.2");
			obj2.transform.position = new Vector3(-1, 0, 0);
			SwapObj(obj1, obj2);
			print($"obj1 : {obj1.name}, obj2 : {obj2.name}");

			//이름이 아웃이면 transform을 가져오고 싶다
			GameObject outObj1 = new GameObject("Out");

			outObj1.transform.position = new Vector3(1, 2, 3);

			GameObject outObj2 = new GameObject("Not Out");

			outObj2.transform.position = new Vector3(3, 2, 1);

			//out 키워드 파라미터는 특성상 선언 시 초기화된 값이 의미가 없기 때문에
			//함수 호출과 같은 라인에서 선언이 가능.
			if (TryGetPosition(outObj1, out Vector3 outPos))
			{
				print($"in if outPos : {outPos}");
			}
			if (TryGetPosition(outObj2, out Vector3 outPos2))
			{
				print($"in if outPos2 : {outPos2}");
			}
			print($"out if outPos : {outPos2}");


		}


		private void Swap(ref int a, ref int b)
		{
			int temp = a;
			a = b;
			b = temp;
		}

		private void SwapObj(GameObject obj1, GameObject obj2)
		{
			string temp = obj1.name;
			obj1.name = obj2.name;
			obj2.name = temp;
		}

		//out : 전통적인 프로그래밍 문법에서 리턴은 단 하나.
		//하지만, 함수 수행 후 받고싶은 결과에 데이터가 여러개일 경우에는 어떡하나?

		private object[] TryGetComponent(Type type)
		{   //불만족스러운 리턴
			Component comp = GetComponent(type);
			bool boolReturn = comp is not null;
			return new object[2] { boolReturn, comp };
		}
		//return은 기본적인 반환만 하고, 추가적인 데이터는 out 파라미터로 전달된 변수에 대입하는 걸로 대체.
		//함수에 out 키워드가 포함됭더 있을 경우 해당 함수는 무조건 그 파라미터를 초기화 해야 함.

		private bool TryGetPosition(GameObject target, out Vector3 pos)
		{   //만약 target.name이 "Out"이면 Pos에 target.transform.position을 대입
			//아니면 Vector3.zero를 대입.
			//out을 매개변수로 받을 시 반환 타입을 추가하는 거나 마찬가지이므로 out의 매개변수에 값을 대입해두어야 리턴이 가능.
			if (target.name == "Out")
			{
				pos = target.transform.position;
				return true;
			}
			else
			{
				pos = Vector3.zero;
				return false;
			}
		}

	}
}
