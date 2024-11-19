using UnityEngine;
using UnityEngine.UI;


// Delegate 키워드의 용도 1 : 대리자, 함수의 이름을 대체
// 내부적으로 일종의 class처럼 동작한다.

namespace Test
{
	//            [반환형] 델리게이트 이름(매개변수)
	public delegate void SomeMethod(int a);			// return이 없는 함수(Method)
	public delegate int SomeFunction(int a, int b);	// 
	
	// delegate 키워드의 용도 2 : 무명 메서드 선언 및 정의으로 활용 
	public class DelegateTest : MonoBehaviour
	{
		public Text text;
		private void Start()
		{
			SomeMethod myMethod = PrintInt;
			myMethod(1);	// console : 1 출력
			myMethod += CreateInt;
			myMethod(2);	// console : 2 출력, Hierarchy에 2라는 이름의 GameObject 생성
			myMethod -= PrintInt;
			myMethod(3);	// Hierarchy에 3라는 이름의 GameObject 생성
			myMethod -= CreateInt;
			myMethod(4);	// nullReferenceException 발생
			myMethod?.Invoke(4);	// nullReferenceException 발생 하지 않음

			if (myMethod != null)
				// 가독성을 위해 Invoke를 사용하는 것을 권장
				myMethod.Invoke(4);	// nullReferenceException 발생 하지 않음
			
			SomeMethod delegateisclass = new SomeMethod(PrintInt);
			delegateisclass(5);	// console : 5 출력

			SomeFunction idontknow = Plus;

			int firstReturn = idontknow(1, 2);
			print(firstReturn);
			idontknow += Multiple;
			int secondReturn = idontknow(1, 2);
			// delegate에 +=으로 여러함수를 추가하면, 마지막 함수의 반환값만 반환한다.
			print(secondReturn);

			string stringA = new string("123");
			string stringB = "123";

			// 무명 메서드의 단점 : 해당 메서드를 추후 다시 참조할 수 없다.
			SomeMethod someUnnamedMethod = delegate(int a) { text.text = a.ToString(); };
			myMethod += someUnnamedMethod;
			
			someUnnamedMethod(4);

			// 1차 간소화 : delegate 키워드 대신 => 연산자로 대체
			someUnnamedMethod = (int i) => { text.text = i.ToString(); };
			
			// 2차 간소화 : 파라미터 데이터 타입을 생략 가능
			someUnnamedMethod += (b) => 
			{
				print(b);
				text.text = b.ToString();
			};
			
			// 3차 간소화 : 함수 내용이 1줄일때
			someUnnamedMethod += b => text.text = b.ToString();
			
			// return 생략 가능
			SomeFunction someUnnamedFunction = (someInta, someIntb) => Plus(someInta, someIntb);
			
			// .netFramework 내장 delegate
			
			// 1. Action : 반환형이 없는 delegate
			// 파라미터가 없는 메서드(Action)
			System.Action noneParamMethod = () => print("NoneParamMethod");
			// 파라미터가 있는 메서드(Action)
			System.Action<int> intParamMethod = (a) => print(a);
			System.Action<int, string> intParamMethod2 = (intA, stringB) => print(intA.ToString() + stringB);
			// 2. Func : 반환형이 있는 delegate
			System.Func<int> noneFunc = () => { return 3;};
			System.Func<int, string> intParamFunc = (int a) => { return a.ToString();};
			// 3. Predicate : 반환형이 bool인 delegate
			System.Predicate<int> isEven = (a) => a % 2 == 0;
			// 매개변수가 하나만 가능하다.
			// System.Predicate<int, int> isBigger = (a, b) => a > b;
			
			// 정렬 기준 정하는 delegate
			System.Comparison<Color> comparison =  (a, b) => a.a.CompareTo(b.a);
		}

		private void PrintInt(int num)
		{
			print(num);
		}

		private void CreateInt(int num)
		{
			new GameObject().name = num.ToString();
		}
		private int Plus(int a, int b)
		{
			return a + b;
		}

		private int Multiple(int a, int b)
		{
			return a * b;
		}

		private float PlusFlot(float a, float b)
		{
			return a + b;
		}
	}
}
