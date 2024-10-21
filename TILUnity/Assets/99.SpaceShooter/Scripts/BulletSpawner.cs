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
		// Instantiate() : 프리팹을 복제하여 씬에 생성하는 함수
		// Instantiate(프리팹, 위치, 회전)
		// Quaternion.identity : 회전값을 없애는 값
		Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>().dir = Vector3.up;
	}
}
