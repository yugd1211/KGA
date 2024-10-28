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


    private bool isPaused = false;

    //Reset ?醫롫솭??덉굲?醫롫짗???醫롫셾??뚯굲 : ?醫롫짗??용쐻??덉굲?醫롫짗??됰뱜?醫롫짗??筌ｌ꼪???덉굲 ?醫롫짗??용쐻??덉굲?醫롫뼄椰꾧퀡????醫롫짗??용쐻??덉굲?醫롫짗??됰뱜 ?醫롫솭?癒?굲?醫롫짗??Reset?醫롫짗???醫롫짗??용쐻??덉굲?醫롫짗???醫롫짗??용쐻??硫⑤쐻??덉굲
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


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(isPaused = !isPaused);
            Time.timeScale = isPaused ? 0 : 1;
        }

        playerHPBar.fillAmount = GameManager.Instance.player.hpAmount;
        killCount.text = $"????: {GameManager.Instance.player.KillCount}";
        totalKillCount.text = $"??リ턃?? ????: {GameManager.Instance.player.TotalKillCount}";
        levelText.text = $"Level : {GameManager.Instance.player.Level}";
        expText.text = $"Exp : {GameManager.Instance.player.exp}";
        damageText.text = $"Damage : {GameManager.Instance.player.Damage}";
        hpText.text = $"HP : {GameManager.Instance.player.hp}";
    }


    public void OnReStart()
    {
        Start();
    }
}
