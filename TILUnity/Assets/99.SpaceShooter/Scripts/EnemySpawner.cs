using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemyPrefab;
	public GameObject leftWall;
	public GameObject rightWall;
	public List<Enemy> enemys;
	public float y;

	private void Start()
	{
		StartCoroutine(SpawnCoroutine());
	}

	private IEnumerator SpawnCoroutine()
	{
		while (true)
		{
			Spawn();
			yield return new WaitForSeconds(1f);
		}
	}

	public void Spawn()
	{
		float x = Random.Range(leftWall.transform.position.x, rightWall.transform.position.x);
		Vector3 position = new Vector3(x , y, 0);
		enemys.Add(Instantiate(enemyPrefab, position, Quaternion.identity).GetComponent<Enemy>());
	}
}
