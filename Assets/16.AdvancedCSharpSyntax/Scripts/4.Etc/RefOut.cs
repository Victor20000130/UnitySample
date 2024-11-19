using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject
{
	public class RefOut : MonoBehaviour
	{
		//ref Ű���� : Value Ÿ��(enum, struct, literal) �����͸� �Ķ���͸� ���� �Լ��� ������ ���.
		//�޸� ���� �����Ͽ� �����ϴµ�, �̸� ������ �� ��ü�ϴ� �Ķ���͸� ������ ��쿡 ���.

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

			//�̸��� �ƿ��̸� transform�� �������� �ʹ�
			GameObject outObj1 = new GameObject("Out");

			outObj1.transform.position = new Vector3(1, 2, 3);

			GameObject outObj2 = new GameObject("Not Out");

			outObj2.transform.position = new Vector3(3, 2, 1);

			//out Ű���� �Ķ���ʹ� Ư���� ���� �� �ʱ�ȭ�� ���� �ǹ̰� ���� ������
			//�Լ� ȣ��� ���� ���ο��� ������ ����.
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

		//out : �������� ���α׷��� �������� ������ �� �ϳ�.
		//������, �Լ� ���� �� �ް���� ����� �����Ͱ� �������� ��쿡�� ��ϳ�?

		private object[] TryGetComponent(Type type)
		{   //�Ҹ��������� ����
			Component comp = GetComponent(type);
			bool boolReturn = comp is not null;
			return new object[2] { boolReturn, comp };
		}
		//return�� �⺻���� ��ȯ�� �ϰ�, �߰����� �����ʹ� out �Ķ���ͷ� ���޵� ������ �����ϴ� �ɷ� ��ü.
		//�Լ��� out Ű���尡 ���ԉ�� ���� ��� �ش� �Լ��� ������ �� �Ķ���͸� �ʱ�ȭ �ؾ� ��.

		private bool TryGetPosition(GameObject target, out Vector3 pos)
		{   //���� target.name�� "Out"�̸� Pos�� target.transform.position�� ����
			//�ƴϸ� Vector3.zero�� ����.
			//out�� �Ű������� ���� �� ��ȯ Ÿ���� �߰��ϴ� �ų� ���������̹Ƿ� out�� �Ű������� ���� �����صξ�� ������ ����.
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
