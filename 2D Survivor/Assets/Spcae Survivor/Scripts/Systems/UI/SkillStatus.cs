using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillStatus : MonoBehaviour
{
	public SkillSlot skillSlot;

	public TextMeshProUGUI titleText;
	public TextMeshProUGUI levelText;

	private void Reset()
	{
		titleText = transform.Find("TitleText").GetComponent<TextMeshProUGUI>();
		levelText = transform.Find("LevelText").GetComponent<TextMeshProUGUI>();
	}

	private void OnEnable()
	{
		UpdateText();
	}

	public void UpdateText()
	{
		titleText.text = $"{skillSlot.skillName}";
		levelText.text = $"Lv.{skillSlot.skillLevel}";
	}
}
