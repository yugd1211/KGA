using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public Enemy enemyPrefab;
	public float spawnRate = 1f;
	public Transform[] point;

	private void Start()
	{
		StartCoroutine(SpawnCoroutine());
	}

	private void Spawn()
	{
		Instantiate(enemyPrefab, point[Random.Range(0, point.Length)].position, Quaternion.identity);
	}

	private IEnumerator SpawnCoroutine()
	{
		while (true)
		{
			Spawn();
			yield return new WaitForSeconds(spawnRate);
		}
	}
}
