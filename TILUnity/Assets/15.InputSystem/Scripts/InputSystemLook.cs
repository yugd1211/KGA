using UnityEngine;
using UnityEngine.InputSystem;
using InputContext = UnityEngine.InputSystem.InputAction.CallbackContext;

public class InputSystemLook : MonoBehaviour
{
	public Transform cameraRig;
	public float mouseSensivity;

	private float rigAngle = 0f;


	public InputActionAsset controlDefine;
	private InputAction lookAction;

	private void Awake()
	{
		controlDefine = GetComponent<PlayerInput>().actions;
		lookAction = controlDefine.FindAction("Look");
	}

	private void OnEnable()
	{
		lookAction.performed += OnLookEvent;
		lookAction.canceled += OnLookEvent;
	}

	private void OnDisable()
	{
		lookAction.performed -= OnLookEvent;
		lookAction.canceled -= OnLookEvent;
	}

	public void OnLookEvent(InputContext value)
	{
		Vector2 mouseDelta = value.ReadValue<Vector2>();

		Look(mouseDelta);
	}

	public void OnLook(InputValue value)
	{
		Vector2 mouseDelta = value.Get<Vector2>();

		Look(mouseDelta);
	}

	private void Look(Vector2 dir)
	{

		transform.Rotate(0, dir.x * mouseSensivity * Time.deltaTime, 0);

		rigAngle -= dir.y * mouseSensivity * Time.deltaTime;
		rigAngle = Mathf.Clamp(rigAngle, -90f, 90f);
		cameraRig.localEulerAngles = new Vector3(rigAngle, 0, 0);

		//transform.Rotate(0, dir.x * mouseSensivity * Time.deltaTime, 0);
		//rigAngle -= dir.y * mouseSensivity * Time.deltaTime;
		//rigAngle = Mathf.Clamp(rigAngle, -90, 90);
		//cameraRig.localEulerAngles = new Vector3(rigAngle, 0, 0);
	}
}
