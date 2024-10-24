using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLaserShotgun : LLaserGun
{
	public Transform[] shotPoints;
	protected override IEnumerator FireCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(shotInterval);
			Fire();
		}
	}

	protected override void Fire()
	{
		foreach (Transform shotpoint in shotPoints)
		{
			Projectile proj = projPool.Pop();
			proj.transform.position = transform.position;
			proj.damage = damage;
			proj.moveSpeed = projectileSpeed;
			proj.transform.localScale *= projectileScale;
			proj.transform.up = shotpoint.transform.position - transform.position;
			proj.pierceCount = pierceCount;
		}
	}

}
