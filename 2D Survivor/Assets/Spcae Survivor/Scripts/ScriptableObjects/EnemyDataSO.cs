using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyDataSO : ScriptableObject
{
	public string enemyName;
	public int level;
	public float hp;
	public float damage;
	public float moveSpeed;
}
