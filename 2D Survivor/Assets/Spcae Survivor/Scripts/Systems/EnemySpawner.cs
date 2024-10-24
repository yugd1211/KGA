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
	public Transform[] point;

	private void Start()
	{
		StartCoroutine(SpawnCoroutine());
	}

	private void Spawn(int spawnCount)
	{
		while (0 < spawnCount--)
		{
			Vector2 playerPos = GameManager.Instance.player.transform.position;
			// ���̰� 1�� �� �ȿ��� ���� ��ġ�� ��ǥ�� ��ȯ
			Vector2 spawnPos;
			float currentDistance = float.MaxValue;

			//int loopCount = 0;
			//do
			//{
			//	// �÷��̾�κ��� �Ÿ��� 0 ~ minMaxDist.y ������ ��ǥ�� ����
			//	spawnPos = Random.insideUnitCircle * minMaxDist.y;
			//	loopCount++;
			//}
			//while (spawnPos.magnitude < minMaxDist.x);
			//print($"loopCount : {loopCount}");
			//// �ѹ��� �����ϴ� ��쵵 ������	������ ���� �ʴ� ��ǥ�� ���ͼ� ���� ���� �󵵰� ����
			//// �������� ���� ��ǥ�� ������ ���ǿ� �°� ����




			//Vector2 ranPos = Random.insideUnitCircle;
			//Vector2 normalizedPos = ranPos.normalized;
			//float moveRad = minMaxDist.y - minMaxDist.x; // 5 - 3 = 2
			//Vector2 notSpawnAreaVector = normalizedPos * minMaxDist.x;
			//Vector2 movedPos = ranPos * moveRad;
			//spawnPos = movedPos + notSpawnAreaVector;





			spawnPos = Random.insideUnitCircle.normalized * Random.Range(minMaxDist.x, minMaxDist.y);
			//print(spawnPos.magnitude);

			Enemy e = PoolManager.Instance.enemyPool.Pop();
			e.gameObject.SetActive(true);
			e.transform.position = playerPos + spawnPos;
			e.transform.SetParent(transform);
			//Instantiate(enemyPrefab, playerPos + spawnPos, Quaternion.identity);
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
