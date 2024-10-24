using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class LLaserGun : MonoBehaviour
{
	public Transform target;
	public Projectile ProjectilePrefab; // 투사체 프리팹
	public ProjectilePool projPool;     //Projectile Prefab로 만들어진 게임 오브젝트를 관리하는 오브젝트 풀


	public float damage;                // 공격력
	public float projectileSpeed;       // 투사체 속도
	public float projectileScale;       // 투사체 크기
	public float shotInterval;          // 발사 간격


	public int projectileCount;         // 투사체 개수
	public float innerInterval;         // 투사체 사이의 간격
	public int pierceCount;             // 관통 횟수
	protected virtual void Start()
	{
		StartCoroutine(FireCoroutine());
	}

	protected virtual void Update()
	{
		if (target == null)
			return;
		transform.up = target.position - transform.position;
	}

	// 공격 코루틴
	protected virtual IEnumerator FireCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(shotInterval);
			// 1. 투사체 개수가 올라가면 0.05초 간격으로 투사체 개수만큼 발사 반복
			for (int i = 0; i < projectileCount; i++)
			{
				Fire();
				yield return new WaitForSeconds(innerInterval);
			}
		}
	}

	protected virtual void Fire()
	{
		Projectile proj = projPool.Pop();

		proj.transform.SetPositionAndRotation(transform.position, transform.rotation);
		proj.damage = damage;
		proj.moveSpeed = projectileSpeed;
		proj.transform.localScale *= projectileScale;
		proj.pierceCount = pierceCount;
	}
}
