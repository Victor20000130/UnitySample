using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using SAA = MyProject.SuperAwesomeAttribute;
//Reflection : System.Reflection ���ӽ����̽��� ���Ե� ��� ����.
//������ Ÿ�ӿ��� �������� Ŭ����, �޼���, ������� �� ���� ���ؽ�Ʈ�� ���� �����͸�
//�����ϰ� ����ϴ� ���.
//Attribute�� ������ Ÿ�ӿ��� �����ϴ� ��Ÿ�������̹Ƿ� ���÷����� ���� �����͸� ������ �� �ִ�.

namespace MyProject
{

	[RequireComponent(typeof(AttributeTest))]
	public class ReflectionTest : MonoBehaviour
	{
		AttributeTest attTest;

		private void Awake()
		{
			attTest = GetComponent<AttributeTest>();
		}
		private void Start()
		{
			//attTest�� Ÿ���� Ȯ��
			MonoBehaviour attTestBoxingForm = attTest;
			Type attTestType = attTestBoxingForm.GetType();
			print(attTestType);

			//AttributeTest��� Ŭ������ �����͸� ������� �������� �ð�
			BindingFlags bind = BindingFlags.Public | BindingFlags.Instance;
			//public���� ������ ������ ���ÿ� Static�� �ƴ϶� ��ü���� ������ field �Ǵ� propertie
			//attTestType : attTest�� GetType�� ���� Ŭ���� ���� ���� �����͸� ������ ����.
			FieldInfo[] fieldInfos = attTestType.GetFields(bind);
			foreach (FieldInfo fi in fieldInfos)
			{
				print($"{fi.Name}�� Ÿ���� {fi.FieldType}");
				SAA attribute = fi.GetCustomAttribute<SAA>();
				if (attribute is null)
				{
					print($"{fi.Name}���� SSA�� ����.");
					continue;
				}
				print($"{fi.Name}���� ���� ��� ��Ʈ����Ʈ�� ����.");
				print($"{attribute.getAwesomeMessage}, {attribute.message}");
				print($"MONO : {fi.GetValue(attTestBoxingForm)}");
				print($"attTest : {fi.GetValue(attTest)}");

			}
		}
	}
}
