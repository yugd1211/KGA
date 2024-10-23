using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
	public Image playerHPBar;
	public TextMeshProUGUI playerKillCount;
	public TextMeshProUGUI levelText;
	public TextMeshProUGUI expText;
	public TextMeshProUGUI damageText;
	public TextMeshProUGUI hpText;

	[HideInInspector]
	public Player player;

	private void Start()
	{
		player = FindObjectOfType<Player>();
	}

	private void Update()
	{
		playerHPBar.fillAmount = player.hpAmount;
		playerKillCount.text = $"Å³ ¼ö : {player.KillCount.ToString()}";
		levelText.text = $"Level : {GameManager.Instance.player.Level.ToString()}";
		expText.text = $"Exp : {GameManager.Instance.player.Exp.ToString()}";
		damageText.text = $"Damage : {GameManager.Instance.player.Damage.ToString()}";
		hpText.text = $"HP : {GameManager.Instance.player.hp.ToString()}";
	}
}
