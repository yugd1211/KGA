using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class AttributeController : MonoBehaviour
{
	// Scene에 있는 모든 Color 어트리뷰트를 찾아서 색을 입혀주는 역할
	private void Start()
	{
		// Color Attribute를 가진 필드를 찾자
		// BindingFlags bind = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
		// MonoBehaviour[] monoBehaviours = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
		// foreach (MonoBehaviour monoBehaviour in monoBehaviours)
		// {
		// 	Type type = monoBehaviour.GetType(); // 타입 정보를 가져옴
		//
		// 	// List<FieldInfo> fieldinfos = new List<FieldInfo>(type.GetFields(bind));
		// 	// List<FieldInfo> colorAttributeAttachedFields  = fieldinfos.FindAll((x) => x.HasAttribute<ColorAttribute>());
		// 	
		// 	// 리스트 등 Collection에서 탐색은 Linq를 통해 간소화 할 수도 있음
		// 	// 1. Linq에서 제공하는 확장 메서드 사용
		// 	IEnumerable<FieldInfo> colorAttachedFields =
		// 		type.GetFields(bind).Where(x => x.HasAttribute<ColorAttribute>());
		// 	
		// 	// 2. SQL 쿼리문처럼 사용가능
		// 	colorAttachedFields = 
		// 		from field in type.GetFields(bind)
		// 		where field.HasAttribute<ColorAttribute>()
		// 		select field;
		//
		// 	foreach (FieldInfo fieldInfo in colorAttachedFields)
		// 	{
		// 		ColorAttribute colorAttribute = fieldInfo.GetCustomAttribute<ColorAttribute>();
		// 		object value = fieldInfo.GetValue(monoBehaviour);
		//
		// 		if (value is Renderer rend)
		// 		{
		// 			rend.material.color = colorAttribute.color;
		// 		}
		// 		else if (value is Graphic graphic)
		// 		{
		// 			graphic.color = colorAttribute.color;
		// 		}
		// 		else
		// 		{
		// 			Debug.LogError("Renderer나 Graphic이 아닌 필드에 ColorAttribute가 붙어있습니다.");
		// 		}
		// 	}
		// }

		BindingFlags bind = BindingFlags.Public | BindingFlags.Instance;
		MonoBehaviour[] monoBehaviours = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
		foreach (MonoBehaviour monoBehaviour in monoBehaviours)
		{
			Type type = monoBehaviour.GetType();
			List<FieldInfo> fieldInfos = new List<FieldInfo>(type.GetFields());
			List<FieldInfo> scaleFields = fieldInfos.FindAll((x) => x.HasAttribute<SizeAttribute>());
			foreach (FieldInfo scaleField in scaleFields)
			{
				print(scaleField);
				// scaleField는 리플렉션으로 런타임시 결정나기 때문에 런타임시의 자신의 객체를 확인할수없다.
				// 때문에 monoBehaviour(런타임에서 결정된 객체)를 통해 값을 가져와야한다.
				SizeAttribute sizeAttribute = scaleField.GetCustomAttribute<SizeAttribute>();
				object currObj = scaleField.GetValue(monoBehaviour);
				if (currObj is Renderer rend)
					rend.transform.localScale *= sizeAttribute.scale;
				else if (currObj is Graphic graphic)
					graphic.transform.localScale *= sizeAttribute.scale;
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

public static class AttributeHelper
{
	public static bool HasAttribute<T>(this MemberInfo info) where T : Attribute
	{
		return info.GetCustomAttributes(typeof(T), true).Length > 0;
	}
}