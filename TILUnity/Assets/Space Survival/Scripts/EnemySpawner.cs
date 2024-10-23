using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemyPrefab;
	public float spawnInterval;

	private void Start()
	{
		StartCoroutine(SpawnCoroutine());
	}


	private void Spawn()
	{
		Instantiate(enemyPrefab);
	}

	private IEnumerator SpawnCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(spawnInterval);
			Spawn();
		}
	}

}
