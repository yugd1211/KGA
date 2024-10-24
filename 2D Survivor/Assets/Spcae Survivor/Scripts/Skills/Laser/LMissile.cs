using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMissile : MonoBehaviour
{
	public Transform target;
	// ���� ���� �ִ� Ÿ�� ���, ���� ��ġ�� ������ ����

	// LMissileProjectile Ŭ���� �����Ұ�
	public LMissileProjectile projectilePrefab;

	public float damage;
	public float projectileSpeed;
	public float projectileScale;
	public float shotInterval;

	public float maxDist; // �ִ� �Ÿ�

	private void Update()
	{
	}

	private void Start()
	{
		_ = StartCoroutine(FireCoroutine());
	}

	private IEnumerator FireCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(shotInterval);
			Fire();
		}
	}


	private void Fire()
	{
		//Vector2 randPos = Random.insideUnitCircle * Random.Range(1, maxDist + 1);
		//GameObject go = new GameObject();
		//go.transform.position = randPos;
		//target = go.transform;


		Vector2 pos = Random.insideUnitCircle * maxDist;

		LMissileProjectile proj = Instantiate(projectilePrefab, pos, Quaternion.identity);
		// ���� ��ġ�� �������Ʈ ���� �� transform�������� ����

		proj.damage = damage;
		proj.duration = 1 / projectileSpeed;
		//proj.moveSpeed = projectileSpeed;
		//proj.transform.position = transform.position;
		//proj.transform.localScale = Vector3.one * projectileScale;

	}

}
