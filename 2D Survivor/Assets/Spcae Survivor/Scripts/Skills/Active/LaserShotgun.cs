using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShotgun : LaserGun
{
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
		int count = projectileCount + GameManager.Instance.player.projectileCount;

		transform.up = GameManager.Instance.player.fireDir;
		for (int i = 0; i < count; i++)
		{
			Projectile proj = PoolManager.Instance.projectilePool.Pop();
			proj.gameObject.SetActive(true);
			proj.transform.position = transform.position;
			proj.damage = Damage;
			proj.moveSpeed = moveSpeed;
			proj.transform.up = transform.up;
			if (i != 0)
				proj.transform.eulerAngles += new Vector3(0, 0, 15 * ((i + 1) / 2) * (i % 2 == 1 ? -1 : 1));
			proj.pierceCount = pierceCount;
		}
	}
}
