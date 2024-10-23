using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item
{
	public float hp = 5f;

	public override void Contact()
	{
		Destroy(gameObject);
		GameManager.Instance.player.Heal(hp);
		base.Contact();
	}

	//public void OnTriggerEnter2D(Collider2D other)
	//{
	//	if (!other.CompareTag("Player"))
	//		return;
	//	Contact();
	//}
}
