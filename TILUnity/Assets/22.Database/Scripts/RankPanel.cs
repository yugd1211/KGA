using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RankPanel : MonoBehaviour
{
	public RankSlotUI rankSlotUIPrefab;
	public Transform content;
	private List<RankSlotUI> ranks = new List<RankSlotUI>();

	public void SetData(List<UserData> userDataList)
	{
		foreach (UserData userData in userDataList)
		{
			RankSlotUI rankSlot = Instantiate(rankSlotUIPrefab, content);
			ranks.Add(rankSlot);
			rankSlot.SetData(userData);
		}
	}

	private void OnDisable()
	{
		foreach (RankSlotUI rankSlot in ranks)
		{
			Destroy(rankSlot.gameObject);
		}
		ranks.Clear();
	}
}
