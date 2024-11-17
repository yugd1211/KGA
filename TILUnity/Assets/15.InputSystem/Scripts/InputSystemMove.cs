using UnityEngine;
using UnityEngine.InputSystem;
using InputContext = UnityEngine.InputSystem.InputAction.CallbackContext;

[RequireComponent(typeof(CharacterController), typeof(Animator), typeof(PlayerInput))]
public class InputSystemMove : MonoBehaviour
{
	public float walkSpeed;
	public float runSpeed;
	private Vector2 smoothValue;

	private CharacterController charCtrl;
	private Animator animator;
	private Vector2 inputValue; 

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
		moveAction.performed += OnMoveEvent;
		moveAction.canceled += OnMoveEvent;
	}

	private void OnDisable()
	{
		moveAction.performed -= OnMoveEvent;
		moveAction.canceled -= OnMoveEvent;
	}

	public void OnMoveEvent(InputContext value)
	{
		if (!value.performed)
			smoothValue = Vector2.zero;
		inputValue = value.ReadValue<Vector2>();
	}

	private void Update()
	{
		Vector3 inputMoveDir = new Vector3(smoothValue.x, 0, smoothValue.y) * walkSpeed;
		// Vector3 inputMoveDir = new Vector3(inputValue.x, 0, inputValue.y) * walkSpeed;
		if (smoothValue.magnitude < 1f)
			Vector2.SmoothDamp(Vector2.zero, inputValue, ref smoothValue, 1f);
		Vector3 actualMoveDir = transform.TransformDirection(inputMoveDir);
		// print($"{inputValue}, smoothValue : {smoothValue}, {smoothValue},   {actualMoveDir}");
		charCtrl.Move(actualMoveDir * Time.deltaTime);

		animator.SetFloat("Xdir", inputValue.x);
		animator.SetFloat("Ydir", inputValue.y);
		animator.SetFloat("Speed", inputValue.magnitude);

	}
}
