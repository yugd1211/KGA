using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Item
{
	// 특정 메시지함수가 없는 Component는 Enable/Disable이 동작하지 않는다.
	// Awake는 Component가 활성화 되어있지 않아도 호출된다.
	// Start, Update는 Component가 활성화 되어있을 때만 호출된다.

	public override void Contact()
	{
		GameManager.Instance.EnemyAllKill();
		base.Contact();
	}

	//public void OnTriggerEnter2D(Collider2D other)
	//{
	//	if (!other.CompareTag("Player"))
	//		return;
	//	Contact();
	//}

}
