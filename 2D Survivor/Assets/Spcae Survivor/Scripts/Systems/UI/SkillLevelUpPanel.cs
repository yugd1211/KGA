using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillLevelUpPanel : MonoBehaviour
{
	public RectTransform list;
	public SkillLevelUpButton buttonPrefab;

	// 플레이어가 레벨업을 하면 패널 활성화 요청
	public void LevelUpPanelOpen(List<SkillSlot> skillList, Action<SkillSlot> callback)
	{
		List<SkillSlot> selectedSkillList = new();
		Time.timeScale = 0;

		while (selectedSkillList.Count < 2)
		{
			int ranNum = UnityEngine.Random.Range(0, skillList.Count); //랜덤한 숫자 하나 뽑기

			SkillSlot selectedSkill = skillList[ranNum]; //랜덤하게 선택된 스킬 가져오기

			if (selectedSkillList.Contains(selectedSkill))
				continue;
			selectedSkillList.Add(selectedSkill); // 뽑힌 스킬을 List에 집어넣음
			SkillLevelUpButton skillButton = Instantiate(buttonPrefab, list); // 선택된 스킬을 레벨업 하는 버튼을 생성
			skillButton.SetSkillSelectButton(selectedSkill.skillName,
				() =>
				{
					callback(selectedSkill);
					LevelUpPanelClose();
				}); // 버튼을 누르면 callback을 호출
		}
	}

	// 레벨업 패널을 닫을시 LevelUpPanelOpen의 callback을 호출
	public void LevelUpPanelClose()
	{
		foreach (Transform buttons in list)
		{
			Destroy(buttons.gameObject);
		}
		Time.timeScale = 1;
		gameObject.SetActive(false);
	}
}
