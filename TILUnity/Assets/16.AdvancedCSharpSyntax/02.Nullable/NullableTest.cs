using UnityEngine;

public class NullableTest : MonoBehaviour
{
	// nullable 문법 : ? 연산자를 사용하여 null을 허용하는 변수를 선언할 수 있다.

	public bool isBlue;

	private Renderer rend;

	private MyClass myClass;
	private Vector2? nullableVector; // 구조체도 nullable가능
	
	// 리터럴 타입(값타입) 필드를 객체처럼 null 또는 주소(Instance hash)를 사용하고 싶을 때
	// 거의 c++의 포인터와 비슷한 형태로 쓰고 싶을때 사용, type 뒤에 ? 붙이고, 이를 nullable type이라고 한다.
	private int? nullableInt;

	private void Awake()
	{
		rend = GetComponent<Renderer>();
	}
	private void Start()
	{
		// 1. 3항 연산자 : bool ? 조건 true : 조건 false;
		rend.material.color = isBlue ? Color.blue : Color.red;
		
		// 2. "?." ,  "??" : null 체크 기능
		// a. 객체?.함수();

		MyClass myClass1 = null;

		myClass1?.GetA();
		myClass1 = new MyClass() { a = 1 };
		myClass1?.GetA();
		
		// b-1. 객체?.필드 : 필드가 참조타입일 경우에만 가능. 객체가 null일 경우 NullReferenceException을 방지하기 위해 사용
		myClass1 = null;
		GameObject someObj = myClass1?.go;
		myClass1 = new MyClass();
		GameObject go = myClass1?.go;
		
		// b-2. 객체?.참조필드??다른필드또는 객체 : 객체가 null일 경우, ??뒤의 값이 대입됨
		GameObject go2 = myClass1?.go ?? new GameObject();
		
		// c. 객체?.값필드??(필수)대체 값 : 객체가 null일 경우, 접근하는 필드가 리터럴 타입이라면 무조건 대체 값이 지정되야 한다.
		int someInt = myClass1?.a ?? 0;
			
		// 위의 코드를 풀어서쓰면 다음과 같다.
		if (myClass1 != null)
			someInt = myClass1.a;
		else
			someInt = 0;

		if (isBlue)
		{
			// _ = StartCoroutine()
		}
		
		print("nullableInt = " + nullableInt);

		string intToText = 1.ToString();
		intToText = nullableInt.ToString();
		intToText = nullableInt?.ToString() ?? 0.ToString();
		print($"intToText = {intToText}");
		nullableInt = 2;

		int localInt = 3;
		nullableInt = localInt;
		// nullable변수는 암시적 변환이 되지 않음
		// localInt = nullableInt;
		localInt = nullableInt.Value;
		print(localInt);
		nullableInt = null;
		
		
		if (nullableInt.HasValue) // value가 null이 아닌지 체크
			print(nullableInt.Value); // InvalidOperationException: Nullable object must have a value.
		localInt = nullableInt ?? 0;
	}

	public class MyClass
	{
		public int a;
		public GameObject go;

		public MyClass()
		{
			go = new GameObject();
		}

		public int GetA()
		{
			Debug.Log("Return A");
			return a;
		}
	}
}
