using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserGun : Skill
{
	public Transform target;

	public float damage;
	public float duration;
	public float moveSpeed;
	public int pierceCount;

	public int projectileCount;


	protected Coroutine skillCoroutine;
	protected Vector2 dir;

	protected bool isFire = false;

	protected virtual void Start()
	{
		skillCoroutine = StartCoroutine(FireCoroutine());
	}
	protected virtual IEnumerator FireCoroutine()
	{
		while (true)
		{
			print(isFire);
			if (isFire)
			{
				Fire();
				yield return new WaitForSeconds(interval);
			}
			//isFire = false;
			yield return null;
		}
	}

	// update에서 사용자가 입력했을시 true로 계속 바꿔준다.
	// 그렇기 때문에 입력받지 않았을때 false로 바꾸기 위해 LateUpdate에서 false로 바꿔준다.
	private void LateUpdate()
	{
		//isFire = false;
	}

	public override void UseSkill(Transform target)
	{
		isFire = true;
		print("UseSkill");
		dir = target.position - transform.position;
		print($"LaserGun UseSkill = dir: {dir}, {target.position} - {transform.position}");
		transform.up = dir;
		transform.up = GameManager.Instance.player.fireDir;
	}

	protected virtual void Fire()
	{
		print("fire");
		transform.up = dir;
		Projectile projectile = PoolManager.Instance.projectilePool.Pop();
		projectile.gameObject.SetActive(true);
		projectile.transform.position = transform.position;
		//Projectile projectile = ProjectilePool.pool.Pop();
		//Projectile projectile = Instantiate(prefab, transform.position, Quaternion.identity);
		projectile.damage = damage;
		projectile.duration = duration;
		projectile.moveSpeed = moveSpeed;
		projectile.transform.up = dir;
	}
}
