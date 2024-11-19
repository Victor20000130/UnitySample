using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace MyProject
{
	//Attribute : ������ �ǹ� (�Ӽ�, Ư��, Ư¡���� ����)
	//C#������ Attribute : Ư�� ���ؽ�Ʈ(Ŭ���� ����, �Լ�, ������ ����)�� ����
	//������ Ÿ�Կ��� �־����� ��Ÿ������.
	public class AttributeTest : MonoBehaviour
	{
		//Attribute ����� : ��� ���ؽ�Ʈ �տ� [] ���̿�
		//Attribute Ŭ������ ����� Ŭ������ �̸�(���� Attribute�� �� �̸�)�� ������ �ȴ�.

		[TextArea(4, 15)]
		public string SomeText;

		[SuperAwesome(getAwesomeMessage = "Not Awesome", message = "Not Cool")]
		public int awesomeInt;

	}

	//�����ڰ� �ۼ��� Ŀ���� ��Ʈ����Ʈ(System.Attribute�� ����� Ŭ����) �տ�
	//AttributeUseageAttribute��� ��Ʈ����Ʈ�� �߰��Ͽ� �ش� ��Ʈ����Ʈ�� ����� �����ϰų� �߰� ������ ����.
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
	public class SuperAwesomeAttribute : Attribute
	{
		public string message;
		public string getAwesomeMessage;
		public SuperAwesomeAttribute()
		{
			message = "i'm Super Awesome!";
			getAwesomeMessage = "Super Awesome!";
		}

		public SuperAwesomeAttribute(string message)
		{
			this.message = message;
		}
	}

}








//	[SerializeField]
//	private int imPrivate;
//	public MyColor color;
//}

//[Serializable]
//public class MyColor //: ISerializable
//{
//	public float red;
//	public float green;
//	public float blue;
//	public float alpha;

//	//public void GetObjectData(SerializationInfo info, StreamingContext context)
//	//{
//	//}

