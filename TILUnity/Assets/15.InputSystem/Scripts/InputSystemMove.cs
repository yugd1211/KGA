using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using InputContext = UnityEngine.InputSystem.InputAction.CallbackContext;

[RequireComponent(typeof(CharacterController), typeof(Animator), typeof(PlayerInput))]
public class InputSystemMove : MonoBehaviour
{
	public float walkSpeed;
	public float runSpeed;

	private CharacterController charCtrl;
	private Animator animator;
	private Vector2 inputValue; // 보간할 방향값

	public InputActionAsset controlDefine;
	private InputAction moveAction;

	private void Awake()
	{
		charCtrl = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
		controlDefine = GetComponent<PlayerInput>().actions;
		moveAction = controlDefine.FindAction("Move");
	}

	private void OnEnable()
	{
		//moveAction.started -> XXDown, MounseButtonDown 과 같음
		moveAction.performed += OnMoveEvent;
		//moveAction.started += OnMoveEvent;
		// MounseButtonUp 과 같음
		moveAction.canceled += OnMoveEvent;
		//controlDefine.
	}

	private void OnDisable()
	{
		moveAction.performed -= OnMoveEvent;
		moveAction.canceled -= OnMoveEvent;
	}

	public void OnMoveEvent(InputContext value)
	{
		inputValue = value.ReadValue<Vector2>();
	}

	private void OnMove(InputValue value)
	{
		//value.isPressed
		inputValue = value.Get<Vector2>();
	}


	private void Update()
	{
		Vector3 inputMoveDir = new Vector3(inputValue.x, 0, inputValue.y) * walkSpeed;
		Vector3 actualMoveDir = transform.TransformDirection(inputMoveDir);

		charCtrl.Move(actualMoveDir * Time.deltaTime);

		animator.SetFloat("Xdir", inputValue.x);
		animator.SetFloat("Ydir", inputValue.y);
		animator.SetFloat("Speed", inputValue.magnitude);

	}
}
