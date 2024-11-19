
// using 키워드
// 1. 외부의 라이브러리 중 사용할 라이브러리를 추가
// C/C++의 #include 와 비슷하고, Java의 import와 비슷하다.

using System;
using System.Net.Http;
using UnityEngine;

// 2. 현재 스크립트(.cs)에서 사용할 컨텍스트(클래스, 구조체, 대리자 등) 이름을 지정
using Random = UnityEngine.Random;
using Ran = UnityEngine.Random;



public class Using : MonoBehaviour
{
	// c++의 소멸자(~)를 c#에서도 정의가능하지만
	// IDisposable 인터페이스를 통해 Dispose()를 호출하도록 한다.
	private void Start()
	{
		// 3. using 키워드를 사용하여 블록 내에서만 사용할 수 있는 컨텍스트를 지정
		// IDisposable 인터페이스를 구현한 객체가 특정 블록 내에서만 동작을 한 후에 블록 끝에서 암시적으로 메모리를 해제하도록 하는 기능
		using (HttpClient httpClient = new HttpClient())
		{
		}

		HttpClient client = new HttpClient();
		client.Dispose();
	}
}