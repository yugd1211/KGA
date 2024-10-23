using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Item
{
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
