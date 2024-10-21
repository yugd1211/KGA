using SpaceShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace SpaceShooter
{
	public class GameManager : MonoBehaviour
    {
		static GameManager _Instance = null;
		public GameObject gameoverMessage;
		public GameObject retryButton;
		public Player player;

		public static GameManager Instance
		{
			get
			{
				if (_Instance == null) _Instance = new GameManager();
				return _Instance;
			}
		}



		void Start()
        {
        
        }

        void Update()
        {
        
        }


		public void GameOver()
		{
			gameoverMessage.SetActive(true);
			retryButton.SetActive(true);
			Time.timeScale = 0;
		}

		public void Retry()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			Time.timeScale = 1;
		}
	}
}