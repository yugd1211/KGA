using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankSlotUI : MonoBehaviour
{
	public TextMeshProUGUI userName;
	public TextMeshProUGUI characterClass;
	public TextMeshProUGUI level;
	
	public void SetData(UserData userData)
	{
		this.userName.text = userData.userName;
		this.characterClass.text = userData.characterClass;
		this.level.text = $"Lv.{userData.level}";
	}	
}
