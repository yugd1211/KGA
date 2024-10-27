using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
	// 1. ���� �ѹ� ������ �� 1������ �ƴ϶� 2 ~ 10 ���� �����ϵ��� ����
	// 2. �� ���� ��ġ�� Vector2.zero�� �ƴ�, �÷��̾� ���� Ư�� �Ÿ� �̻� ��ġ�� ����
	[Tooltip("�ѹ��� ������ ���� ��.\nx : �ּ�, y : �ִ�")]
	public Vector2Int minMaxCount;
	[Tooltip("�ѹ��� ������ �� �÷��̾�κ����� �ּ�, �ִ� �Ÿ�\n.x : �ּ�, y : �ִ�")]
	public Vector2 minMaxDist;

	public float spawnRate = 1f;

	private void Start()
	{
		StartCoroutine(SpawnCoroutine());
	}

	private void Spawn(int spawnCount)
	{
		while (0 < spawnCount--)
		{
			Vector2 playerPos = GameManager.Instance.player.transform.position;
			Vector2 spawnPos = Random.insideUnitCircle.normalized * Random.Range(minMaxDist.x, minMaxDist.y);

			Enemy e = PoolManager.Instance.enemyPool.Pop();
			e.gameObject.SetActive(true);
			e.transform.position = playerPos + spawnPos;
			e.transform.SetParent(transform);
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(Vector3.zero, minMaxDist.x);
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(Vector3.zero, minMaxDist.y);

	}

	private IEnumerator SpawnCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(spawnRate);
			int enemyCount = Random.Range(minMaxCount.x, minMaxCount.y);
			Spawn(enemyCount);
		}
	}
}
