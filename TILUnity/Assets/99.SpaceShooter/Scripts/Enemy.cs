using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	private float xBoundaryMinSize = -3.5f;
	private float xBoundaryMaxSize = 3.5f;

	private float yBoundaryMinSize = 3f;
	private float yBoundaryMaxSize = 4.5f;
	Rigidbody2D rigidbody2D;


	private void Awake()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Wall"))
			Destroy(gameObject);
	}
}
