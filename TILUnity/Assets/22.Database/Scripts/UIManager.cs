using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public UISignUp signUp; // 회원가입 페이지
	public UILogIn logIn; // 로그인 페이지
	public UIUserInfo userInfo; // 유저 정보 페이지
	public UIPopup popup; // 팝업 페이지
	public RankPanel rankPanel; // 랭킹 페이지
	
	private Dictionary<string, GameObject> pages = new Dictionary<string, GameObject>();
	private GameObject currentPage; // 현재 열려 있는 페이지

	public static UIManager Instance;
	private void Awake()
	{
		Instance = this;
		pages.Add("SignUp", signUp.gameObject);
		pages.Add("LogIn", logIn.gameObject);
		pages.Add("UserInfo", userInfo.gameObject);
		pages.Add("Popup", popup.gameObject);
		pages.Add("Ranking", rankPanel.gameObject);
	}

	private void Start()
	{
		foreach (GameObject page in pages.Values)
		{
			page.SetActive(false);
		}
		PageOpen("LogIn");
	}

	public void PageOpen(string pageName)
	{
		if (pages.ContainsKey(pageName))
		{
			currentPage?.SetActive(false);
			currentPage = pages[pageName];
			currentPage.SetActive(true);
		}
	}
}
