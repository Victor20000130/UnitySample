using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
namespace MyProject
{
	public class AttributeController : MonoBehaviour
	{//scene에 모든 color 어트리뷰트를 찾아서 색을 입혀주는 역할로 만들고 싶다.
		private void Start()
		{
			//Color Attribute를 가진 필드를 찾자
			BindingFlags bind = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
			MonoBehaviour[] monoBehaviours =
				FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
			foreach (MonoBehaviour monoBehaviour in monoBehaviours)
			{
				Type type = monoBehaviour.GetType(); // 타입 정보를 가져옴.

				//List<FieldInfo> fieldInfos = new List<FieldInfo>(type.GetFields(bind));
				//List<FieldInfo> colorAttributeAttachedFields =
				//	fieldInfos.FindAll((x) =>
				//	{
				//		return x.HasAttribute<ColorAttribute>();
				//	});


				//리스트 등 collection에서 탐색은
				//Linq를 통해 간소화 할 수도 있음.
				//1.Linq에서 제공하는 확장 메서드 사용
				IEnumerable<FieldInfo> colorAttachedFields =
					type.GetFields(bind).Where(x => x.HasAttribute<ColorAttribute>());

				//2.SQL, 쿼리문과 비슷한 형태로도 사용이 가능.
				colorAttachedFields =
				from field in type.GetFields(bind)
				where field.HasAttribute<ColorAttribute>()
				select field;

				foreach (FieldInfo fi in colorAttachedFields)
				{
					ColorAttribute att = fi.GetCustomAttribute<ColorAttribute>();
					object value = fi.GetValue(monoBehaviour);

					if (value is Renderer rend)
					{
						rend.material.color = att.color;
					}
					else if (value is Graphic graphic)
					{
						graphic.color = att.color;
					}
					else
					{
						Debug.LogError("Color 어트리뷰트가 잘못된 곳으로 가버렷어..");
					}
				}
			}

			foreach (MonoBehaviour monoBehaviour in monoBehaviours)
			{
				Type type = monoBehaviour.GetType();
				IEnumerable<FieldInfo> scaleAttachedFields =

				type.GetFields(bind).Where(x => x.HasAttribute<SizeAttribute>());
				scaleAttachedFields =
							from field in type.GetFields(bind)
							where field.HasAttribute<SizeAttribute>()
							select field;

				//Debug.Log(scaleAttachedFields.ToString());
				foreach (FieldInfo fi in scaleAttachedFields)
				{
					Debug.Log(fi.Name);
					SizeAttribute sAtt = fi.GetCustomAttribute<SizeAttribute>();
					object value = fi.GetValue(monoBehaviour);
					if (value == null)
					{
						Debug.LogError($"{fi.Name} 필드 null");
						continue;
					}
					if (value is Transform transform && value is not RectTransform rect)
					{
						transform.localScale = sAtt.scale;
					}
					else if (value is RectTransform rectTransform)
					{
						rectTransform.sizeDelta = sAtt.sizeDelta;
					}
					else
					{
						Debug.LogError("아앗...!! 잘못된 크기가..!!");
					}
				}

			}




		}

	}

	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class ColorAttribute : Attribute
	{
		public Color color;
		public ColorAttribute(float r = 0, float g = 0, float b = 0, float a = 1)
		{
			color = new Color(r, g, b, a);
		}

	}

	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class SizeAttribute : Attribute
	{
		public Vector3 scale;
		public Vector2 sizeDelta;
		public SizeAttribute(float x = 1, float y = 1, float z = 1)
		{
			scale = new Vector3(x, y, z);
		}
		public SizeAttribute(float width, float height)
		{
			sizeDelta = new Vector2(width, height);
		}

	}

	public static class AttributeHelper
	{
		public static bool HasAttribute<T>(this MemberInfo info) where T : Attribute
		{
			return info.GetCustomAttributes(typeof(T), true).Length > 0;
		}
	}
}
