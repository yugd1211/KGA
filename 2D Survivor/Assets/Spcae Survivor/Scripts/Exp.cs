using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour, IItem
{
	int value = 10;
	public void Contact()
	{
		Destroy(gameObject);
		GameManager.Instance.player.Exp += value;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collision.CompareTag("Player"))
			return;
		Contact();
	}
}
