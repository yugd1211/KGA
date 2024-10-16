using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMessageTest : MonoBehaviour
{
	// 물리적인 충돌 또는 상호작용에 의해서 호출되는 메세지
	// OnCollisionxxx() 메세지 호출 조건 : 호출 될 컴포넌트에 Collider 컴포넌트가 부착되어 있어야 한다.
	// 메시지 함수를 호출하는 객체는 Rigidbody이다. 그러므로 둘중 하나는 Rigidbody가 붙어여한다.


	// 1. OnCollisionEnter : 물리적인 충돌이 발생했을 때 호출되는 메세지 함수
	private void OnCollisionEnter(Collision collision)
	{
		Collider otherCollider = collision.collider;	// 충돌이 발생한 대상

		print($"충돌 발생 : {otherCollider.name}");
	}

	// 2. OnCollisionExit : 물리적인 충돌이 끝났을 때 호출되는 메세지 함수
	private void OnCollisionExit(Collision collision)
	{
		Collider otherCollider = collision.collider;    // 충돌이 발생한 대상

		print($"충돌끝 : {otherCollider.name}");
	}

	// 3. OnCollisionStay : 물리적인 충돌이 지속되는 동안 호출되는 메세지 함수
	private void OnCollisionStay(Collision collision)
	{
		Collider otherCollider = collision.collider;    // 충돌이 발생한 대상

		print($"충돌중~~~~~~~~~~~~~~~~~ : {otherCollider.name}");
	}
}
