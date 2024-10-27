using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;

public class StatusPanel : MonoBehaviour
{
	public TextMeshProUGUI levelText;
	public TextMeshProUGUI expText;
	public TextMeshProUGUI damageText;
	public TextMeshProUGUI hpText;

	public GameObject skillList;
	public SkillStatus skillStatusPrefab;

	private void Reset()
	{
		Transform status = transform.Find("Stats");
		levelText = status.Find("Level").GetComponent<TextMeshProUGUI>();
		expText = status.Find("Exp").GetComponent<TextMeshProUGUI>();
		damageText = status.Find("Damage").GetComponent<TextMeshProUGUI>();
		hpText = status.Find("Hp").GetComponent<TextMeshProUGUI>();

		skillList = transform.Find("SkillList").gameObject;
	}
	private void Start()
	{
		foreach (SkillSlot skill in GameManager.Instance.player.skillSlots)
		{
			SkillStatus s = Instantiate(skillStatusPrefab, skillList.transform);
			s.skillSlot = skill;
			s.UpdateText();
		}
	}

	private void OnEnable()
	{
		levelText.text = $"레벨 : {GameManager.Instance.player.Level}";
		expText.text = $"경험치 : {GameManager.Instance.player.exp}";
		damageText.text = $"공격력 : {GameManager.Instance.player.Damage}";
		hpText.text = $"체력 : {GameManager.Instance.player.hp}";
	}
}
