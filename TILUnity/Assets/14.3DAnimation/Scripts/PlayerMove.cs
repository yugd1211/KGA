using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class PlayerMove : MonoBehaviour
{
	#region Private Components

	private CharacterController charCtrl;
	private Animator anim;
	#endregion

	#region Public Fiuelds

	public float walkSpeed;
	public float runSpeed;

	#endregion

	#region Private Fields

	private float currentSpeed;

	#endregion

	private void Awake()
	{
		charCtrl = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
	}

	private void Update()
	{
		Move();
	}

	private void Move()
	{
		Vector3 inputValue = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		// ClampMagnitude�??�용?�여 ?�각선 ?�동 ?�도�?1�??�한
		// normalize�??�면 0 ~ 1??1�??�것?�기 ?�문??
		inputValue = Vector3.ClampMagnitude(inputValue, 1);

		float runValue = Input.GetAxis("Fire3");

		currentSpeed = inputValue.magnitude * walkSpeed + (runValue * (runSpeed - walkSpeed));

		Vector3 inputMoveDir = inputValue * currentSpeed;

		Vector3 acturalMove = transform.TransformDirection(inputMoveDir);

		charCtrl.Move(acturalMove * Time.deltaTime);

		anim.SetFloat("Xdir", inputValue.x);
		anim.SetFloat("Ydir", inputValue.z);
		anim.SetFloat("Speed", inputValue.magnitude + runValue);
	}
}
