using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public Vector3 dir;
	public float moveSpeed = 10f;

	private void Update()
	{
		transform.Translate(dir * Time.deltaTime * moveSpeed);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
		else if (collision.gameObject.CompareTag("Wall"))
			Destroy(gameObject);
	}
}
