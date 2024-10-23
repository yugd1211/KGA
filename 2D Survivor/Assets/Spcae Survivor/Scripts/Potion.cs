using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour, IItem
{
	public float hp = 5f;

	public void Contact()
	{
		Destroy(gameObject);
		GameManager.Instance.player.Heal(hp);
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag("Player"))
			return;
		Contact();
	}
}
