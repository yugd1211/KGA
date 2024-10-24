using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;


// �⺻���� ��ü������ ���� �̱��� ��ü�� ����� ���
// ���� ��ü ������ �Ѱ��ϴ� ������Ʈ
public class GameManager : MonoBehaviour
{
	private static GameManager instance;
	public static GameManager Instance => instance;
	private GameManager() {/* �����ڸ� private�� �����Ͽ� �ܺο��� ������ ���´�. */}


	public GameObject LevelUpUi;

	internal List<Enemy> enemies = new List<Enemy>();
	internal Player player;
	internal event Action enemyAllKillEvent;
	internal ItemSpawner itemSpawner;

	// ����Ƽ���� �̱��� ������ �����ϴ� ���
	private void Awake()
	{
		if (instance != null)
		{
			DestroyImmediate(this);
			return;
		}
		instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public void TimeStop()
	{
		Time.timeScale = 0;
	}

	public void TimeResume()
	{
		LevelUpUi.SetActive(false);
		Time.timeScale = 1;
	}
	private void Start()
	{
		itemSpawner = FindObjectOfType<ItemSpawner>();

	}

	public void EnemyAllKill()
	{
		enemyAllKillEvent?.Invoke();
		//List<Enemy> snapshot = new List<Enemy>(enemies);
		//foreach (Enemy enemy in snapshot)
		//	enemy.TakeDamage(enemy.hp + 1);
	}
}