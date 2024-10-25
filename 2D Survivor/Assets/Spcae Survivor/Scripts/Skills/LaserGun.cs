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
	protected virtual void Start()
	{
		skillCoroutine = StartCoroutine(FireCoroutine());
	}
	protected virtual IEnumerator FireCoroutine()
	{
		while (true)
		{
			for (int i = 0; i < projectileCount; i++)
			{
				Fire();
				yield return new WaitForSeconds(interval / projectileCount);
			}
			yield return new WaitForSeconds(interval);
		}
	}

	// update에서 사용자가 입력했을시 true로 계속 바꿔준다.
	// 그렇기 때문에 입력받지 않았을때 false로 바꾸기 위해 LateUpdate에서 false로 바꿔준다.

	//public override void UseSkill(Transform target)
	//{
	//	dir = target.position - transform.position;
	//}


	protected virtual void Fire()
	{
		//transform.up = dir;
		transform.up = GameManager.Instance.player.fireDir;
		Projectile projectile = PoolManager.Instance.projectilePool.Pop();
		projectile.gameObject.SetActive(true);
		projectile.transform.position = transform.position;
		projectile.damage = damage;
		projectile.duration = duration;
		projectile.moveSpeed = moveSpeed;
		projectile.pierceCount = pierceCount;
		projectile.transform.up = GameManager.Instance.player.fireDir;
	}

	public override void UseSkill(Transform target)
	{
		throw new System.NotImplementedException();
	}
}
