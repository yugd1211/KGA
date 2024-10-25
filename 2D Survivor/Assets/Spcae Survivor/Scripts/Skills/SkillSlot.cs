using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[Serializable]
public class SkillSlot
{
	public string skillName = "Skill";
	public float interval = 1;
	public int skillLevel = 0;
	public bool isTargeting = false;
	public Skill[] skillPrefabs; // 5개의 프리팹을 참조하여 각 레벨에 맞는 프리팹을 로드하도록 활용
	public Skill currentSkillOjbect;

	public void CreatePrefab(UnityEngine.Transform parent)
	{
		if (currentSkillOjbect != null)
			GameObject.Destroy(currentSkillOjbect.gameObject); // 기존에 있던 스킬 오브젝트 제거
		currentSkillOjbect = GameObject.Instantiate(skillPrefabs[skillLevel], parent, false);
		currentSkillOjbect.name = skillPrefabs[skillLevel].name;
		currentSkillOjbect.transform.localPosition = Vector2.zero;
		if (isTargeting)
		{
			//skill.currentSkillOjbect.transform.SetParent(fireDir);
		}

	}
}
