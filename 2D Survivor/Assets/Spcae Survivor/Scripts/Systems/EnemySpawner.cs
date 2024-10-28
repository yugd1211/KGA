using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
	[Tooltip("?좎떬諭꾩삕?좎룞???좎룞?쇿뜝?숈삕?좎룞???좎룞?쇿뜝?숈삕 ?좎룞??\nx : ?좎뙇?쎌삕, y : ?좎뙇?먯삕")]
	public Vector2Int minMaxCount;
	[Tooltip("?좎떬諭꾩삕?좎룞???좎룞?쇿뜝?숈삕?좎룞???좎룞???좎떆琉꾩삕?좎떛?듭삕鰲?좎룞?쇿뜝?숈삕???좎뙇?쎌삕, ?좎뙇?먯삕 ?좎떊紐뚯삕\n.x : ?좎뙇?쎌삕, y : ?좎뙇?먯삕")]
	public Vector2 minMaxDist;

	public float spawnRate = 1f;

	public EnemyDataSO[] enemyDatas;

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

			// Enemy e = PoolManager.Instance.enemyPool.Pop();
			Enemy e = PoolManager.Instance.Get<Enemy>();
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
