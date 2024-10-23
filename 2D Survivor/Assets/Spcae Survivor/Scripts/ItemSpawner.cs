using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
	public int spawnInterval = 10;
	public List<GameObject> itemPrefabs;
	public Transform[] SpawnPos;

	private List<IItem> items = new List<IItem>();
	private Exp exp;


	private void Start()
	{
		List<GameObject> tmp = new List<GameObject>();
		foreach (GameObject item in itemPrefabs)
		{
			if (item.GetComponent<IItem>() != null)
				tmp.Add(item);
		}
		itemPrefabs = tmp;
		exp = itemPrefabs.Find(x => x.GetComponent<Exp>() != null).GetComponent<Exp>();
		StartCoroutine(SpawnCoroutine());
	}

	public void SpawnExp(Vector2 spawnPos)
	{
		items.Add(Instantiate(exp, spawnPos, Quaternion.identity).GetComponent<IItem>());
	}

	private void Spawn()
	{
		items.Add(Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Count)], SpawnPos[Random.Range(0, SpawnPos.Length)].position, Quaternion.identity).GetComponent<IItem>());
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
