using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAs : MonoBehaviour
{
	// is, as : 참조타입의 캐스팅(형변환)과 관련이 있다.
	// is 키워드 : 객체가 특정 타입인지 확인하는 키워드
	// as 키워드 : 객체를 특정 타입으로 변환하는 키워드

	class A
	{
		// 사용자 정의 암시적 변환 연산자
		// as 키워드를 사용할 때 사용자 정의 암시적 변환 연산자를 사용할 수 있다.
		public static implicit operator GameObject(A a) => GameObject.Find("A");
		public static object operator ==(A a, A b) => a.Equals(b);
		public static object operator !=(A a, A b) => !a.Equals(b);
	}
	class B : A {}
	
	private void Start()
	{
		A a = new A();
		B b = a as B; // as : ()를 사용한 명시적 캐스팅과 달리 캐스팅 불가능 하더라도 Exception을 발생시키지 않는다. 대신 null을 반환
		// ()를 사용한 명시적 캐스팅보다 효율적인 연산이다.
		// 단점 : 사용자 정의 명시적 및 암시적 변환 연산자를 활용하지 못함
		
		// b가 null이 아니면 b의 type을 출력하고, null이면 "b is null"을 출력한다.
		print(b?.GetType().ToString() ?? "b is null");
		
		// is : as가 직접 캐스팅 한 객체가 결과로 오는 대신, 캐스팅 가능한지 여부만 true/false로 연산됨
		
		print(a is A);
		print(a is B);
		
		// 둘의 결과는 같으나 내부동작이 다르다.
		// is : == 연산자보다 효율적이나 사용자 정의 연산자를 사용하지 못함
		print(b is null);
		
		// ==은 연산자 오버라이딩이 가능하다.
		print(b == null);
	}
}
