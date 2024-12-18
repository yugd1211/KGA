using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILogIn : MonoBehaviour
{
	public TMP_InputField email;
	public TMP_InputField passwd;
	public Button loginButton;
	public Button singInButton;

	private void Awake()
	{
		singInButton.onClick.AddListener(SignUpButtonClick);
		loginButton.onClick.AddListener(LoginButtonClick);
	}

	private void OnEnable()
	{
		loginButton.interactable = true;
	}

	private void LoginButtonClick()
	{
		DatabaseManager.Instance.Login(email.text, passwd.text);
		loginButton.interactable = false;
	}

	private void SignUpButtonClick()
	{
		UIManager.Instance.PageOpen("SignUp");
	}
	
}
