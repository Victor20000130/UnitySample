using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using SAA = MyProject.SuperAwesomeAttribute;
//Reflection : System.Reflection 네임스페이스에 포함된 기능 전반.
//컴파일 타임에서 생서오딘 클래스, 메서드, 멤버변수 등 여러 컨텍스트에 대한 데이터를
//색인하고 취급하는 기능.
//Attribute는 컴파일 타임에서 생성하는 메타데이터이므로 리플렉션을 통해 데이터를 가져올 수 있다.

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
			//attTest의 타입을 확인
			MonoBehaviour attTestBoxingForm = attTest;
			Type attTestType = attTestBoxingForm.GetType();
			print(attTestType);

			//AttributeTest라는 클래스의 데이터를 요목조목 따져보는 시간
			BindingFlags bind = BindingFlags.Public | BindingFlags.Instance;
			//public으로 접근이 가능한 동시에 Static이 아니라 객체별로 생성할 field 또는 propertie
			//attTestType : attTest의 GetType을 통해 클래스 명세에 대한 데이터를 가지고 있음.
			FieldInfo[] fieldInfos = attTestType.GetFields(bind);
			foreach (FieldInfo fi in fieldInfos)
			{
				print($"{fi.Name}의 타입은 {fi.FieldType}");
				SAA attribute = fi.GetCustomAttribute<SAA>();
				if (attribute is null)
				{
					print($"{fi.Name}에는 SSA가 없음.");
					continue;
				}
				print($"{fi.Name}에는 슈퍼 어썸 어트리뷰트가 있음.");
				print($"{attribute.getAwesomeMessage}, {attribute.message}");
				print($"MONO : {fi.GetValue(attTestBoxingForm)}");
				print($"attTest : {fi.GetValue(attTest)}");

			}
		}
	}
}
