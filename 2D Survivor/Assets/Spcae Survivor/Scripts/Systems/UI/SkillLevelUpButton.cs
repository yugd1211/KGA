using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillLevelUpButton : MonoBehaviour
{
	public TextMeshProUGUI skillNameText;
	public Button button;

	public void SetSkillSelectButton(string skillName, UnityAction onClick)
	{
		skillNameText.text = skillName;
		button.onClick.AddListener(onClick);
	}
}
