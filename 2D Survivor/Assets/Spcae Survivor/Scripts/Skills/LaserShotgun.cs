using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShotgun : LaserGun
{
	public Transform[] shotPoints;
	public Vector2 dir;


	public override void UseSkill(Transform target)
	{
		isFire = true;
		dir = target.position - transform.position;
		print($"UseSkill = dir: {dir}, {target.position} - {transform.position}");
		transform.up = dir;
		print(transform.name);
		//transform.up = GameManager.Instance.player.fireDir;
	}

	//private void Update()
	//{
	//	print("Update!!!!!!: " + dir);
	//}

	protected override IEnumerator FireCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(interval);
			Fire();
		}
	}
	protected override void Fire()
	{
		transform.up = dir;

		// 일단 도저히 안되는중, dir이 개판임
		transform.up = GameManager.Instance.player.fireDir;
		print($"dir: {dir} , fire {GameManager.Instance.player.fireDir}");
		foreach (Transform shotpoint in shotPoints)
		{
			Projectile proj = PoolManager.Instance.projectilePool.Pop();
			proj.transform.position = transform.position;
			proj.damage = damage;
			proj.moveSpeed = moveSpeed;
			proj.transform.up = shotpoint.transform.position - transform.position;
			//proj.transform.up = transform.up + new Vector3(0, 0, 15);
			proj.pierceCount = pierceCount;
		}
	}
}
