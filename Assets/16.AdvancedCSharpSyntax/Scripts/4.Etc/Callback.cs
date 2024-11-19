using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�Լ��� ȣ�� �ϰ� ����� � �ٸ� �Լ��� ȣ��Ǿ� �� ��, �װ� �ݹ��Լ���� �θ�.
namespace MyProject
{
	public class Callback : MonoBehaviour
	{   //������ Ư�� �Լ� ���� �Ŀ� �ٸ� �Լ��� ȣ��Ǳ� ���� ��, �� �Լ���
		//C# ver : �븮�� ���·� �ѱ�.
		//javaScript ver : �Լ������ͷ� �ѱ�.

		public GameObject destroyTarget;
		public CallbackTestPopup popup;
		public void OnDestroyButtonClick()
		{

			popup.ShowPopup(
				OnYes
				);

		}


		public void OnYes(bool yes)
		{
			if (yes)
			{
				Destroy(destroyTarget);
			}
			else
			{
				print("���ְڽ�");
			}
		}
	}

}

