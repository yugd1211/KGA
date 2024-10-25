using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : SingletonManager<UIManager>
{
	public Canvas mainCanvas;
	public GameObject pausePanel;
	public SkillLevelUpPanel levelupPanel;

	public Image playerHPBar;
	public TextMeshProUGUI killCount;
	public TextMeshProUGUI totalKillCount;
	public TextMeshProUGUI levelText;
	public TextMeshProUGUI expText;
	public TextMeshProUGUI damageText;
	public TextMeshProUGUI hpText;

	protected override void Awake()
	{
		base.Awake();
	}

	//Reset 메시지 함수 : 컴포넌트가 처음 부착되거나 컴포넌트 메뉴의 Reset을 선택할 경우 호출
	private void Reset()
	{
		mainCanvas = GetComponent<Canvas>();
		pausePanel = transform.Find("PausePanel").gameObject;
		levelupPanel = transform.Find("LevelupPanel").GetComponent<SkillLevelUpPanel>();
	}


	private void Start()
	{
		pausePanel.SetActive(false);
		levelupPanel.gameObject.SetActive(false);
	}

	bool isPaused = false;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			isPaused = !isPaused;
			pausePanel.SetActive(isPaused);
			Time.timeScale = isPaused ? 0 : 1;
		}

		playerHPBar.fillAmount = GameManager.Instance.player.hpAmount;
		killCount.text = $"킬 수 : {GameManager.Instance.player.KillCount.ToString()}";
		totalKillCount.text = $"종합 킬 수 : {GameManager.Instance.player.TotalKillCount.ToString()}";
		levelText.text = $"Level : {GameManager.Instance.player.Level.ToString()}";
		expText.text = $"Exp : {GameManager.Instance.player.exp.ToString()}";
		damageText.text = $"Damage : {GameManager.Instance.player.Damage.ToString()}";
		hpText.text = $"HP : {GameManager.Instance.player.hp.ToString()}";
	}

}
