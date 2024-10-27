using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Missile : Skill
{
	public Transform target;
	public MissileProjectile projectilePrefab;

	public int projectileCount;
	public float projectileSpeed;
	public float projectileScale;

	public float maxDist; // �ִ� �Ÿ�

	private void Start()
	{
		_ = StartCoroutine(FireCoroutine());
	}

	private IEnumerator FireCoroutine()
	{
		while (true)
		{
			int count = projectileCount + GameManager.Instance.player.projectileCount;
			yield return new WaitForSeconds(interval);
			for (int i = 0; i < count; i++)
				Fire();
		}
	}


	private void Fire()
	{
		Vector2 pos = (Vector2)transform.position + Random.insideUnitCircle.normalized * maxDist;
		MissileProjectile proj = Instantiate(projectilePrefab, pos, Quaternion.identity);
		proj.damage = Damage;
		proj.duration = 1 / projectileSpeed;
		//proj.transform.position = transform.position;
		proj.transform.localScale = Vector3.one * projectileScale;
	}
}
