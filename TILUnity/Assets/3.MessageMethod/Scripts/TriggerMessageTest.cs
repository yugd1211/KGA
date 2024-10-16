using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMessageTest : MonoBehaviour
{
	// Collider 컴포넌트의 IsTrigger 속성을 True로 설정해 놓으면 물리적인 충돌을 일으키지 않는 대신 Coliider 영역 내의 다른 collider와 상호 작용이 가능하다.
	// OnCollisionxx 메세지 함수와 마찬가지로 두 객체 중 하나는 반드시 Rigidbody 컴포넌트가 있어야 한다.

	// 1. OnTriggerEnter : Collider 영역 내에 다른 Collider가 들어왔을 때 호출되는 메세지 함수
	private void OnTriggerEnter(Collider other)
	{
		print($"트리거진입  호출 주체 : {name},  대상 : {other.name}");
	}

	// 2. OnTriggerExit : Collider 영역 내에 다른 Collider가 나갔을 때 호출되는 메세지 함수
	private void OnTriggerExit(Collider other)
	{
		print($"트리거나감  호출 주체 : {name},  대상 : {other.name}");
	}

	// 3. OnTriggerStay : Collider 영역 내에 다른 Collider가 머물러 있는 동안 호출되는 메세지 함수
	private void OnTriggerStay(Collider other)
	{
		print($"트리거중~~~~~~~~~  호출 주체 : {name},  대상 : {other.name}");
	}

}
