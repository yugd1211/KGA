using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using InputContext = UnityEngine.InputSystem.InputAction.CallbackContext;

public class InputSystemAction : MonoBehaviour
{
	private Animator animator;
	private Rig rig;
	private WaitUntil untilReload;
	public AnimationClip reloadClip;
	private bool isReloading;
	public InputActionAsset controlDefine;
	private InputAction moveAction;


	private void Awake()
	{
		animator = GetComponent<Animator>();
		rig = GetComponent<RigBuilder>().layers[0].rig;

		controlDefine = GetComponent<PlayerInput>().actions;
		moveAction = controlDefine.FindAction("Reload");
	}

	private IEnumerator Start()
	{
		untilReload = new WaitUntil(() => isReloading);

		while (true)
		{
			yield return untilReload;
			yield return new WaitForSeconds(reloadClip.length);
			isReloading = false;
			rig.weight = 1;
		}
	}

	private void OnEnable()
	{
		moveAction.performed += OnReloadEvent;
		moveAction.canceled += OnReloadEvent;
	}

	private void OnDisable()
	{
		moveAction.performed -= OnReloadEvent;
		moveAction.canceled -= OnReloadEvent;
	}

	public void OnReloadEvent(InputContext value)
	{
		if (value.performed)
		{
			if (isReloading)
				return;
			rig.weight = 0f;
			isReloading = true;
			animator.SetTrigger("Reload");
		}
	}

	public void OnReloadEnd()
	{
		print("OnReloadEnd");
	}

	private void OnReload(InputValue value)
	{
		// Single : float°ú À¯»ç
		print($"OnReload: {value.isPressed}, {value.Get<Single>()}");
		if (isReloading)
			return;
		rig.weight = 0f;
		isReloading = true;
		animator.SetTrigger("Reload");
	}
}
