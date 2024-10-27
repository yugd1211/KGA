using System.Collections.Generic;
using System;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
	private static PoolManager instance;
	public static PoolManager Instance => instance;
	
	public Projectile projectilePrefab;
	public Enemy enemyPrefab;
	public ParticleSystem ParticlePrefab;
	
	public List<Transform> gameObjectPools;
	
	
	private Dictionary<Type, object> pools = new Dictionary<Type, object>();

	public void CreatePool<T>(T prefab) where T : Component
	{
		if (pools.ContainsKey(typeof(T)))
		{
			Debug.LogWarning($"PoolManager CreatePool {typeof(T)} : is already pools");
			return;
		}
		GameObject newGO = new GameObject(typeof(T).ToString());
		newGO.transform.SetParent(transform);
		gameObjectPools.Add(newGO.transform);
		pools.Add(typeof(T), new ObjectPool<T> {prefab = prefab});
	}

	public T Get<T>() where T : Component
	{
		if (pools.ContainsKey(typeof(T)))
			return ((ObjectPool<T>)pools[typeof(T)]).Pop();
		return null;
	}
	
	public T Get<T>(T item) where T : Component
	{
		if (pools.ContainsKey(typeof(T)))
			return ((ObjectPool<T>)pools[typeof(T)]).Pop();
		return null;
	}

	public void Remove<T>(T item) where T : Component
	{
		if (pools.ContainsKey(typeof(T)))
		{
			((ObjectPool<T>)pools[typeof(T)]).Push(item);
			return;
		}
		Debug.LogWarning($"Poolmanager {typeof(T)} is not create Pool {typeof(T).Name}");
	}
	
	private void Awake()
	{
		if (instance != null)
		{
			DestroyImmediate(this);
			return;
		}
		instance = this;
		DontDestroyOnLoad(gameObject);

		CreatePool(projectilePrefab);
		CreatePool(enemyPrefab);
		CreatePool(ParticlePrefab);
	}
}
