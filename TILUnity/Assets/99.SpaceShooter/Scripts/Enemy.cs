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
		RandomPosition();
	}

	private void RandomPosition()
	{
		rigidbody2D.velocity = Vector3.zero;
		float x = Random.Range(xBoundaryMinSize, xBoundaryMaxSize);
		float y = Random.Range(yBoundaryMinSize, yBoundaryMaxSize);
		transform.position = new Vector3(x, y, 0);
	}

	private void Update()
	{
		if (transform.position.y < -5.5f)
		{
			RandomPosition();
		}
	}
}
