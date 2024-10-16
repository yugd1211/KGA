using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace SpaceShooter
{
	public class Player : MonoBehaviour
	{
		public float speed = 5f;
		public float boundaryMinSize = -3.5f;
		public float boundaryMaxSize = 3.5f;

		public GameObject gameoverMessage;
		public GameObject retryButton;


		private void Update()
		{
			// Input : InputManager�� ����� Ȱ���Ͽ� �Է� ó���� �� �� �ִ� Ŭ����
			// Input.GetAxis() // �̸� ���ǵǾ��ִ� �Է� ���� ���� �����´�.
			// Horizontal : x��, Vertical : y��
		
			float x = Input.GetAxis("Horizontal");
			transform.Translate(new Vector3(x, 0, 0) * Time.deltaTime * speed);

			if (transform.position.x <  boundaryMinSize)
				transform.position = new Vector3(boundaryMinSize, transform.position.y);
			if (transform.position.x > boundaryMaxSize)
				transform.position = new Vector3(boundaryMaxSize, transform.position.y);
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("Enemy"))
			{
				GameOver();
			}
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
