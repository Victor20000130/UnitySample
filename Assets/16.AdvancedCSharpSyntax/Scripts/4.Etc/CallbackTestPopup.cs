using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject
{
	public class CallbackTestPopup : MonoBehaviour
	{
		Action<bool> callback;

		private void Start()
		{
			gameObject.SetActive(false);
		}

		public void ShowPopup(Action<bool> callback)
		{
			gameObject.SetActive(true);
			this.callback = callback;
		}

		public void OnButtonDown(bool yes)
		{
			callback?.Invoke(yes);
			gameObject.SetActive(false);
		}
	}
}
