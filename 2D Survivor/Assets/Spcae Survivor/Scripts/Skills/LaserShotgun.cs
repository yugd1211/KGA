using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShotgun : LaserGun
{
	public Transform[] shotPoints;
	//public Vector2 dir;


	public override void UseSkill(Transform target)
	{
		dir = target.position - transform.position;
		transform.up = dir;
	}

	protected override IEnumerator FireCoroutine()
	{
		while (true)
		{
			Fire();
			yield return new WaitForSeconds(interval);
		}
	}

	protected override void Fire()
	{
		transform.up = GameManager.Instance.player.fireDir;
		for (int i = 0; i < projectileCount; i++)
		{
			Projectile proj = PoolManager.Instance.projectilePool.Pop();
			proj.gameObject.SetActive(true);
			print($"i = {i}, {proj.GetInstanceID()}");
			proj.transform.position = transform.position;
			proj.damage = damage;
			proj.moveSpeed = moveSpeed;
			proj.transform.up = transform.up;
			if (i != 0)
				proj.transform.eulerAngles += new Vector3(0, 0, 15 * ((i + 1) / 2) * (i % 2 == 1 ? -1 : 1));
			proj.pierceCount = pierceCount;
		}
	}
}
