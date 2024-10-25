using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class DataManager : SingletonManager<DataManager>
{
	// PlayerPrefs : 디바이스에 저장된 게임 데이터를 불러오거나 디바이스에 저장하는 기능 제공
	// 주로 정적 함수를 호출하여 기능을 활용 한다.
	int killCount;

	public bool clearPrefsOnStart = false;

	private IEnumerator Start()
	{
		if (clearPrefsOnStart) PlayerPrefs.DeleteAll();
		yield return null;
		OnLoad();
	}

	public void OnSave()
	{
		int totalKillCount = GameManager.Instance.player.TotalKillCount;

		// PlayerPrefs의 캐시에 값을 입력 (key : string, value : int)
		PlayerPrefs.SetInt("TotalKillCount", totalKillCount);

		// PlayerPrefs의 값을 저장
		PlayerPrefs.Save();
	}

	public void OnLoad()
	{
		// 해당 key값에 저장된 데이터가 없을때의 기본값을 지정할 수 있다.
		int totalKillCount = PlayerPrefs.GetInt("TotalKillCount", 0);
		GameManager.Instance.player.TotalKillCount = totalKillCount;
	}

	private void OnApplicationQuit()
	{
		OnSave();
	}
}
