using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour, IItem
{
	public void Contact()
	{
		Destroy(gameObject);
		GameManager.Instance.EnemyAllKill();
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag("Player"))
			return;
		Contact();
	}

}
