using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
	// 1. 적이 한번 스폰될 때 1마리가 아니라 2 ~ 10 마리 스폰하도록 변경
	// 2. 적 스폰 위치를 Vector2.zero가 아닌, 플레이어 기준 특정 거리 이상 위치에 스폰
	[Tooltip("한번에 스폰될 적의 수.\nx : 최소, y : 최대")]
	public Vector2Int minMaxCount;
	[Tooltip("한번에 스폰될 때 플레이어로부터의 최소, 최대 거리\n.x : 최소, y : 최대")]
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
			// 길이가 1인 원 안에서 랜덤 위치의 좌표를 반환
			Vector2 spawnPos;
			float currentDistance = float.MaxValue;

			//int loopCount = 0;
			//do
			//{
			//	// 플레이어로부터 거리가 0 ~ minMaxDist.y 사이의 좌표를 받음
			//	spawnPos = Random.insideUnitCircle * minMaxDist.y;
			//	loopCount++;
			//}
			//while (spawnPos.magnitude < minMaxDist.x);
			//print($"loopCount : {loopCount}");
			//// 한번에 스폰하는 경우도 있지만	조건이 맞지 않는 좌표가 나와서 루프 도는 빈도가 높다
			//// 랜덤으로 나온 좌표를 무조건 조건에 맞게 가공




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
