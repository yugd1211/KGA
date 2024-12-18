using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISignUp : MonoBehaviour
{
	public TMP_InputField email;
	public TMP_InputField userName;
	public TMP_InputField passwd;
	
	public Button signUpButton;
	public Button loginButton;

	private void Awake()
	{
		signUpButton.onClick.AddListener(SignUpButtonClick);
		loginButton.onClick.AddListener(LoginButtonClick);
	}
	
	private void OnEnable()
	{
		signUpButton.interactable = true;
	}

	private void LoginButtonClick()
	{
		UIManager.Instance.PageOpen("LogIn");
	}
	
	private void SignUpButtonClick()
	{
		DatabaseManager.Instance.SignUp(email.text, userName.text, passwd.text);
		signUpButton.interactable = false;
	}
}
