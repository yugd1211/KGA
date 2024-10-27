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
	public Skill[] skillPrefabs; 
	public Skill currentSkillOjbect;

	public void CreatePrefab(UnityEngine.Transform parent)
	{
		if (currentSkillOjbect != null)
			GameObject.Destroy(currentSkillOjbect.gameObject); // ?????? ??? ??? ??????? ????
		currentSkillOjbect = GameObject.Instantiate(skillPrefabs[skillLevel], parent, false);
		currentSkillOjbect.name = skillPrefabs[skillLevel].name;
		currentSkillOjbect.transform.localPosition = Vector2.zero;
		if (skillLevel == 0)
			currentSkillOjbect.interval = float.MaxValue;
		else
			currentSkillOjbect.interval = interval;
		if (isTargeting)
		{
			//skill.currentSkillOjbect.transform.SetParent(fireDir);
		}

	}
}
