using System;
using UnityEngine;

public class RefOut : MonoBehaviour
{
	// ref 키워드 : Value 타입(enum, struct, literal) 데이터를 파라미터를 통해 함수에 전달할 경우
	// 메모리에 값을 복사하여 전달 하는데, 이를 포인터로 대체 하는 파라미터를 선언할 경우에 사용
	// c, c++의 포인터와 비슷한 역할을 한다.

	private void Start()
	{
		int a = 10, b = 20;
		Swap(ref a, ref b);
		
		print($"{a}, {b}");

		GameObject go1 = new GameObject("No.1");
		GameObject go2 = new GameObject("No.2");
		
		// SwapObject(ref go1, ref go2);
		print($"{go1.name}, {go2.name}");

		GameObject outObj1 = new GameObject("Out");
		outObj1.transform.position = new Vector3(1, 2, 3);
		GameObject outObj2 = new GameObject("Not Out");
		outObj1.transform.position = new Vector3(3, 2, 1);
		if (TryGetPosition(outObj1, out Vector3 pos))
		{
			print($"Out : {pos}");
		}
		if (TryGetPosition(outObj2, out Vector3 pos2))
		{
			print($"Not Out : {pos2}");
		}
		// out 키워드 파라미터는 특성상 함수내에서 초기화가 이루어지기 때문에
		// 함수 호출 시 초기화를 하지 않아도 된다.
	}

	private void Swap(ref int a, ref int b)
	{
		int temp = a;
		a = b;
		b = temp;
	}
	
	// void SwapObject(ref GameObject a, ref GameObject b)
	// {
	// 	GameObject temp = a;
	// 	a = b;
	// 	b = temp;
	// }
	
	
	// GameObject는 Reference 타입이기 때문에 ref 키워드를 사용하지 않아도 SwapObject 함수를 사용할 수 있다.
	// ref 키워드를 사용하면 주소에 담긴 객체 자체를 바꿀 수 있다.
	void SwapObj(GameObject a, GameObject b)
	{
		string temp = a.name;
		a.name = b.name;
		b.name = temp;
	}
	
	
	// out 키워드 : Reference 타입
	// 전통적인 프로그래밍 문법에서 리턴은 단하나
	// 함수 수행결과 받고싶은 데이터가 여러개일때


	object[] TryGetComponent(Type type)
	{
		// 
		Component comp = GetComponent(type);
		bool boolReturn = comp is not null;
		return new object[2] { boolReturn, comp };
	}
	
	// return은 기본적인 반환만 하고, 추가 데이터는 out 키워드를 사용하여 전달
	// 함수에 out 키워드가 포함되어 있을 경우 해당 함수는 무조건 그 파라미터를 초기화해야 한다.
	bool TryGetPosition(GameObject target, out Vector3 pos)
	// target.name이 Out이면 Pos에 target.transform.position을 대입
	// 아니면 Vector3.zero를 대입
	{
		if (target.name == "Out")
		{
			pos = target.transform.position;
			return true;
		}
		else
		{
			pos = Vector3.zero;
			return false;
		}
	}
}
