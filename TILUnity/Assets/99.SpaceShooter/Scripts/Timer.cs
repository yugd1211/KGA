using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
	public TextMeshProUGUI timerText;
	public float winTime = 10;
	public GameObject winnerText;
	public GameObject retryButton;
	private float t = 0;

	private void Update()
	{
		t += Time.deltaTime;
		if (t >= winTime)
		{
			timerText.text = $"Time : {winTime}";
			GameOver();
		}
		else
			timerText.text = $"Time : {t}";
	}


	private void GameOver()
	{
		Time.timeScale = 0;
		t = 0;
		winnerText.SetActive(true);
		retryButton.SetActive(true);
	}
}
