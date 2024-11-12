using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerPlayerMove : MonoBehaviour
{
	public float moveSpeed = 5f;
	public float turnSpeed = 100f;
	private float gravity = -9.81f;
	private CharacterController cc;

	private void Awake()
	{
		cc = GetComponent<CharacterController>();

	}
	private void Update()
	{
		float inputX = Input.GetAxis("Vertical");
		float inputY = Input.GetAxis("Horizontal");

		if (!cc.isGrounded)
			cc.Move(Vector3.up * gravity * Time.deltaTime);
		cc.Move(cc.transform.forward * inputX * moveSpeed * Time.deltaTime);
		Turn(inputY * turnSpeed * Time.deltaTime);
	}

	private void Turn(float angle)
	{
		transform.Rotate(0, angle, 0);
	}

	//private void OnControllerColliderHit(ControllerColliderHit hit)
	//{
	//	//print($"{hit.collider.}");
	//	hit.collider.BroadcastMessage("PlayerEnter", true);
	//	//print("OnControllerColliderHit : " + hit.collider.name);
	//}
}
