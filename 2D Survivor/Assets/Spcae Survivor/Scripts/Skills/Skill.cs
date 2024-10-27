using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
	
	// 액티브 스킬용
	public float interval;
	public float damage;

	// 옵저버로 해도 될듯
	// player damage를 subject로 설정하고 skill이 알림받으면 damage를 변경하는 식으로
	public float Damage => GameManager.Instance.player.damage + damage;

	// 패시브 스킬도 생겼기 때문에 abstract UseSkill은 삭제함
}
