using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
	public GameObject bulletPrefab;

	private void Start()
	{
		StartCoroutine(SpawnCoroutine());
	}

	IEnumerator SpawnCoroutine()
	{
		while (true)
		{
			Spawn();
			yield return new WaitForSeconds(1f);
		}
	}

	public void Spawn()
	{
		// Instantiate() : �������� �����Ͽ� ���� �����ϴ� �Լ�
		// Instantiate(������, ��ġ, ȸ��)
		// Quaternion.identity : ȸ������ ���ִ� ��
		Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>().dir = Vector3.up;
	}
}
