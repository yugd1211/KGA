using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class LLaserGun : MonoBehaviour
{
	public Transform target;
	public Projectile ProjectilePrefab; // ����ü ������
	public ProjectilePool projPool;     //Projectile Prefab�� ������� ���� ������Ʈ�� �����ϴ� ������Ʈ Ǯ


	public float damage;                // ���ݷ�
	public float projectileSpeed;       // ����ü �ӵ�
	public float projectileScale;       // ����ü ũ��
	public float shotInterval;          // �߻� ����


	public int projectileCount;         // ����ü ����
	public float innerInterval;         // ����ü ������ ����
	public int pierceCount;             // ���� Ƚ��
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

	// ���� �ڷ�ƾ
	protected virtual IEnumerator FireCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(shotInterval);
			// 1. ����ü ������ �ö󰡸� 0.05�� �������� ����ü ������ŭ �߻� �ݺ�
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
