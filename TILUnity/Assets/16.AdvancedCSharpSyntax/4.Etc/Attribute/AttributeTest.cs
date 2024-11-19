using System;
using System.Runtime.Serialization;
using UnityEngine;

// attribute란? 
// 사전적의미 = 속성, 특성, 특징적인 형질
// c#에서 Attribute는 특정 컨텍스트(클래스 정의, 함수 정의, 변수의 선언)에 대한 컴파일 타임에서 주어지는 메타데이터


public class AttributeTest : MonoBehaviour
{
	[SerializeField]
	private int imPrivate;
	public MyColor color;
	
	
	// Attribute를 사용하는 방법. 대상 컨텍스트 앞에 [] 사이에 Attribute 클래스를 상속한 클래스의 이름(에서 Attribute를 뺀 이름)을 적으면 된다.

	[TextArea(4, 15)] public string someText;

	// [SuperAwesome("you are not awesome")] 
	[SuperAwesome(getAwesomeMessage = "1", message = "2")] 
	public int awesomeInt;
}

// 개발자가 작성한 커스텀 어트리뷰트(System.Attribute를 상속한 클래스)앞에
// AttributeUsageAttribute라는 어트리뷰트를 추가하여 해당 어트리뷰트의 사용을 제한하거나 추가 설정이 가능하다.
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
public class SuperAwesomeAttribute : Attribute
{
	public string message;
	public string getAwesomeMessage;
	
	public SuperAwesomeAttribute()
	{
		message = "I'm awesome";
		getAwesomeMessage = "Super Awesome";

	}
	public SuperAwesomeAttribute(string message)
	{
		this.message = message;
	}
}

[Serializable]
public class MyColor : ISerializable
{
	public float red;
	public float green;
	public float blue;
	public float alpha;
	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		throw new NotImplementedException();
	}
} 
