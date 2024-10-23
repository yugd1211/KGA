using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : Skill
{
	public Projectile prefab;
	public float damage;

	private Coroutine skillCoroutine;
	private Vector2 dir;
	private bool isFire = false;

	private void Start()
	{
		skillCoroutine = StartCoroutine(FireCoroutine());

	}
	private IEnumerator FireCoroutine()
	{
		while (true)
		{
			if (isFire)
				Fire(dir);
			yield return new WaitForSeconds(interval);
		}
	}

	// update에서 사용자가 입력했을시 true로 계속 바꿔준다.
	// 그렇기 때문에 입력받지 않았을때 false로 바꾸기 위해 LateUpdate에서 false로 바꿔준다.
	private void LateUpdate()
	{
		isFire = false;
	}

	public override void UseSkill(Transform target)
	{
		isFire = true;
		dir = target.position - transform.position;
	}

	public void Fire(Vector2 dir)
	{
		Projectile projectile = Instantiate(prefab, transform.position, Quaternion.identity);
		projectile.damege = damage;
		projectile.duration = 5f;
		projectile.moveSpeed = 10f;
		projectile.transform.up = dir;
	}
}
