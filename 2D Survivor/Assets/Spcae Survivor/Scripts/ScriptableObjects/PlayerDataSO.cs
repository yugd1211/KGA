using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerDataSO", order = 0)]
public class PlayerDataSO : ScriptableObject
{
	// asset 파일로 생성 후 데이터를 입력할 수 있다.
	public string characterName;
	public float hp;
	public float damage;
	public float moveSpeed;
	public Sprite sprite;
	public GameObject startSkillPrefab;
	public bool rotateRenderer;
}
