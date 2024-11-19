using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//함수를 호출 하고난 결과를 어떤 다른 함수가 호출되야 할 때, 그걸 콜백함수라고 부름.
namespace MyProject
{
	public class Callback : MonoBehaviour
	{   //보통은 특정 함수 수행 후에 다른 함수가 호출되길 원할 때, 그 함수를
		//C# ver : 대리자 형태로 넘김.
		//javaScript ver : 함수포인터로 넘김.

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
				print("봐주겠슈");
			}
		}
	}

}

