using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : SingletonManager<DataManager>
{
    // PlayerPrefs : ?遺얠뺍??곷뮞?????貫留?野껊슣???怨쀬뵠?怨? ?븍뜄???브탢???遺얠뺍??곷뮞?????館釉??疫꿸퀡????볥궗
    // 雅뚯눖以??類ㅼ읅 ??λ땾???紐꾪뀱??뤿연 疫꿸퀡?????뽰뒠 ??뺣뼄.
    int killCount;

    public bool clearPrefsOnStart = false;

    private IEnumerator Start()
    {
        if (clearPrefsOnStart) PlayerPrefs.DeleteAll();
        yield return null;
        OnLoad();
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            print($"??嚥≪뮆諭??${scene.name}");
            if (scene == SceneManager.GetSceneByName("GameScene"))
                OnLoad();
        };
    }

    public void OnSave()
    {
        int totalKillCount = GameManager.Instance.player.TotalKillCount;

        // PlayerPrefs??筌?Ŋ???揶쏅?????낆젾 (key : string, value : int)
        PlayerPrefs.SetInt("TotalKillCount", totalKillCount);

        // PlayerPrefs??揶쏅???????
        PlayerPrefs.Save();
    }

    public void OnLoad()
    {
        // ????key揶쏅?肉????貫留??怨쀬뵠?怨? ??곸뱽???벥 疫꿸퀡??첎誘れ뱽 筌왖?類λ막 ????덈뼄.
        int totalKillCount = PlayerPrefs.GetInt("TotalKillCount", 0);
        GameManager.Instance.player.TotalKillCount = totalKillCount;
    }

    private void OnApplicationQuit()
    {
        print("OnApplicationQuit");
        OnSave();
    }
}
