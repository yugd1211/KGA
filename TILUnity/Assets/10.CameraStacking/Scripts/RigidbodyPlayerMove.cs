using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class RigidbodyPlayerMove : MonoBehaviour
{
	public float moveSpeed = 5f;
	public float turnSpeed = 5f;
	private Rigidbody rb;
	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		Move(inputY * moveSpeed * Time.deltaTime);
		Turn(inputX * turnSpeed * Time.deltaTime);
	}

	private void Move(float speed)
	{
		rb.MovePosition(rb.position + (transform.forward * speed));
		//rb.MovePosition(new Vector3(rb.position.x, rb.position.y, speed));
	}

	private void Turn(float angle)
	{
		rb.MoveRotation(rb.rotation * Quaternion.Euler(0, angle, 0));
	}
}
