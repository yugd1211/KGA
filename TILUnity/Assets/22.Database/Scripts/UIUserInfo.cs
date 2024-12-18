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

	private UserData userData;

	private void Awake()
	{
		levelUpButton.onClick.AddListener(LevelUpButtonClick);
	}
	
	private void LevelUpButtonClick()
	{
		DatabaseManager.Instance.Levelup(userData.email);
	}

	public void UserInfoOpen(UserData userData)
	{
		this.userData = userData;
		
		userName.text = userData.userName;
		characterClass.text = userData.characterClass;
		currentLevel = userData.level;
		level.text = $"Lv.{currentLevel}";
	}
}
