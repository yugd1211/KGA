using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using InputContext = UnityEngine.InputSystem.InputAction.CallbackContext;

public class InputSystemAction : MonoBehaviour
{
	private Animator animator;
	private Rig rig;
	
	
	public InputActionAsset controlDefine;
	private InputAction reloadAction;
	private InputAction grenadeAction;
	private InputAction fireAction;
	
	public AnimationClip reloadClip;
	private WaitUntil untilReload;
	private bool isReloading;
	
	public AnimationClip grenadeClip;
	private WaitUntil untilGrenade;
	private bool isGrenade;
	
	public AnimationClip fireClip;
	private WaitUntil untilFire;
	private bool isFire;


	private void Awake()
	{
		animator = GetComponent<Animator>();
		rig = GetComponent<RigBuilder>().layers[0].rig;
		controlDefine = GetComponent<PlayerInput>().actions;
		reloadAction = controlDefine.FindAction("Reload");
		grenadeAction = controlDefine.FindAction("Grenade");
		fireAction = controlDefine.FindAction("Fire");
	}
	private void OnEnable()
	{
		reloadAction.performed += OnReloadEvent;
		grenadeAction.performed += OnGrenadeEvent;
		fireAction.performed += OnFireEvent;
		reloadAction.canceled += OnReloadEvent;
		grenadeAction.canceled += OnGrenadeEvent;
		fireAction.canceled += OnFireEvent;
	}

	private void OnDisable()
	{
		reloadAction.performed -= OnReloadEvent;
		grenadeAction.performed -= OnGrenadeEvent;
		fireAction.performed -= OnFireEvent;
		reloadAction.canceled -= OnReloadEvent;
		grenadeAction.canceled -= OnGrenadeEvent;
		fireAction.canceled -= OnFireEvent;
	}

	
	
	
	private IEnumerator UntilReload()
	{
		while (true)
		{
			yield return untilReload;
			yield return new WaitForSeconds(reloadClip.length);
			isReloading = false;
			rig.weight = 1;
		}
	}
	
	private IEnumerator UntilGrenade()
	{
		while (true)
		{
			yield return untilGrenade;
			yield return new WaitForSeconds(grenadeClip.length);
			isGrenade = false;
			rig.weight = 1;
		}
	}
	
	private IEnumerator UntilFire()
	{
		while (true)
		{
			yield return untilFire;
			yield return new WaitForSeconds(fireClip.length);
			isFire = false;
			rig.weight = 1;
		}
	}
	

	private void Start()
	{
		untilReload = new WaitUntil(() => isReloading);
		untilGrenade = new WaitUntil(() => isGrenade);
		untilFire = new WaitUntil(() => isFire);

		StartCoroutine(UntilReload());
		StartCoroutine(UntilGrenade());
		StartCoroutine(UntilFire());
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

	public void OnGrenadeEvent(InputContext value)
	{
		if (value.performed)
		{
			if (isGrenade)
				return;
			rig.weight = 0f;
			isGrenade = true;
			animator.SetTrigger("Grenade");
		}
	}
	
	public void OnGrenadeEnd()
	{
		print("OnGrenadeEnd");
	}
	
	public void OnFireEvent(InputContext value)
	{
		if (value.performed)
		{
			if (isFire)	
				return;
			print("OnFire");
			rig.weight = 0f;
			isFire = true;
			animator.SetTrigger("Fire");
		}
	}
}
