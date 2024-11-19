using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject
{
	public class IsAs : MonoBehaviour
	{
		//is as : ����Ÿ���� ĳ����(����ȯ)�� ������ ����.
		class A
		{
			public static implicit operator GameObject(A a) => GameObject.Find("A");
			//public static object operator ==(A a, object b) { return true; }
			//public static object operator !=(A a, object b) { return false; }

		}
		class B : A { }

		private void Start()
		{
			A a = new A();
			B b = a as B;
			//as : ()�� ����� ����� ĳ���ð� �޸� ĳ���� �Ұ����ϴ��� Exception�� ������ ����.
			//��� null�� ��ȯ.
			//()�� ����� ����� ĳ���ú��� ȿ������ ����.
			//��� ����� ���� ����� �� �Ͻ��� ��ȯ �����ڸ� Ȱ������ ����.

			print(b?.GetType().ToString() ?? "B is null");

			//is : as�� ���� ĳ������ ��ü�� ����� ���� ���, ĳ���� �������� ���θ� true/false�� �����.
			print(a is A);
			print(b is A);

			print(b is null);
			//== �����ں��� ȿ����.
			//��� ����� ���� �����ڸ� ������� ����.(�����ε��� ������)

			print(b == null);

		}
	}
}
