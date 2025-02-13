using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIUserInfo : MonoBehaviour
{
	public TextMeshProUGUI userName;
	public TextMeshProUGUI characterClass;
	public TextMeshProUGUI level;

	public int currentLevel;
	
	public Button levelUpButton;
	public Button deleteButton;
	public Button rankButton;

	private UserData userData;

	private void Awake()
	{
		levelUpButton.onClick.AddListener(LevelUpButtonClick);
		deleteButton.onClick.AddListener(DeleteButtonClick);
		rankButton.onClick.AddListener(RankButtonClick);
	}
	
	private void LevelUpButtonClick()
	{
		DatabaseManager.Instance.Levelup(userData.email);
	}
	
	private void RankButtonClick()
	{
		UIManager.Instance.PageOpen("Ranking");
		onRankButtonClick();
	}

	public void UserInfoOpen(UserData userData)
	{
		this.userData = userData;
		
		userName.text = userData.userName;
		characterClass.text = userData.characterClass;
		currentLevel = userData.level;
		level.text = $"Lv.{currentLevel}";
	}
	
	public void DeleteButtonClick()
	{
		DatabaseManager.Instance.Delete(userData.email);
	}
	
	public void onRankButtonClick()
	{
		DatabaseManager.Instance.GetUserRank(10);	
	}

}
