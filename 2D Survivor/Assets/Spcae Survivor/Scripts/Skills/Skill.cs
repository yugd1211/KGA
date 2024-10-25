using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
	public string skillName;
	public float interval;
	public int skillLevel;
	public bool isTargeting;
	public GameObject[] skillPrefabs; // 5개의 프리팹을 참조하여 각 레벨에 맞는 프리팹을 로드하도록 활용

	public abstract void UseSkill(Transform target);
}
