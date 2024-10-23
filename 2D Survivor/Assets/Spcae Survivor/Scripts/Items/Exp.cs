using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : Item
{
	int value = 10;
	public override void Contact()
	{
		GameManager.Instance.player.GainExp(value);
		base.Contact();
	}

	//private void OnTriggerEnter2D(Collider2D collision)
	//{
	//	if (!collision.CompareTag("Player"))
	//		return;
	//	Contact();
	//}
}
