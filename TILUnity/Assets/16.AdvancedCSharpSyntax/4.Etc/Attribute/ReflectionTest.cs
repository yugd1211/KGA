using System;
using System.Reflection;
using UnityEngine;
using SAA = SuperAwesomeAttribute;


// Reflection : System.Reflection 네임스페이스에 포함된 기능 전반
// 컴파일 타임에서 생성된 클래스, 메소드, 멤버 변수 등 여러 컨텍스트에 대한 데이터를 색인하고 취급하는 기능
// Attribute는 컴파일타임에서 생성하는 메타데이터이므로 리플렉션을 통해 데이터를 가져올 수 있다.
[RequireComponent(typeof(AttributeTest))]
public class ReflectionTest : MonoBehaviour
{
	private AttributeTest attTest;

	private void Awake()
	{
		attTest = GetComponent<AttributeTest>();
	}

	private void Start()
	{
		// attTest의 Type을 가져온다.
		MonoBehaviour attTestBoxingForm = attTest;
		Type attTestType = attTestBoxingForm.GetType();
		
		print(attTestType);
		
		// AttributeTest 클래스의 데이터를 분해
		BindingFlags bind = BindingFlags.Public | BindingFlags.Instance;
		// public으로 접근이 가능한 동시에 Static이 아닌 Instace Field 또는 propertie를 가져온다.
		// attTestType : attTest의 GetType을 통해 클래스 명세에 대한 데이터를 가지고 있음
		FieldInfo[] fieldInfos = attTestType.GetFields(bind);

		foreach (FieldInfo fieldinfo in fieldInfos)
		{
			print($"{fieldinfo.Name}의 타입은 {fieldinfo.FieldType}");
			SAA attribute = fieldinfo.GetCustomAttribute<SAA>();
			if (attribute is null)
			{
				print($"{fieldinfo.Name}에는 SuperAwesomeAttribute가 없습니다.");
				continue;
			}
			print($"{fieldinfo.Name}에는 SuperAwesomeAttribute가 있습니다.");
			print($"{attribute.getAwesomeMessage}, {attribute.message}");
			print($"{fieldinfo.GetValue(attTest)}");
			// print(fieldinfo.Name);
		}
	}
}
