using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserGun : Skill
{
	public Transform target;

	public float duration;
	public float moveSpeed;
	public int pierceCount;

	public int projectileCount;

	protected virtual void Start()
	{
		_ = StartCoroutine(FireCoroutine());
	}
	protected virtual IEnumerator FireCoroutine()
	{
		while (true)
		{
			int count = projectileCount + GameManager.Instance.player.projectileCount;
			for (int i = 0; i < count; i++)
			{
				Fire();
				yield return new WaitForSeconds(interval / count);
			}
			yield return new WaitForSeconds(interval);
		}
	}

	// update���� ����ڰ� �Է������� true�� ��� �ٲ��ش�.
	// �׷��� ������ �Է¹��� �ʾ����� false�� �ٲٱ� ���� LateUpdate���� false�� �ٲ��ش�.

	//public override void UseSkill(Transform target)
	//{
	//	dir = target.position - transform.position;
	//}


	protected virtual void Fire()
	{
		//transform.up = dir;
		transform.up = GameManager.Instance.player.fireDir;
		// Projectile projectile = PoolManager.Instance.projectilePool.Pop();
		Projectile projectile = PoolManager.Instance.Get<Projectile>();
		projectile.gameObject.SetActive(true);
		projectile.transform.position = transform.position;
		projectile.damage = Damage;
		projectile.duration = duration;
		projectile.moveSpeed = moveSpeed;
		projectile.pierceCount = pierceCount;
		projectile.transform.up = GameManager.Instance.player.fireDir;
	}

}
