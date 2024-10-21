using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace SpaceShooter
{
	public class Player : MonoBehaviour
	{
		public float speed = 5f;

		private BulletSpawner bulletSpawner;

		private void Start()
		{
			bulletSpawner = GetComponentInChildren<BulletSpawner>();
		}

		private void Update()
		{
			// Input : InputManager의 기능을 활용하여 입력 처리를 할 수 있는 클래스
			// Input.GetAxis() // 미리 정의되어있는 입력 축의 값을 가져온다.
			// Horizontal : x축, Vertical : y축
		
			float x = Input.GetAxis("Horizontal");
			float y = Input.GetAxis("Vertical");
			transform.Translate(new Vector3(x, y, 0) * Time.deltaTime * speed);

			//if (Input.GetKey(KeyCode.Space))
			//{
			//	bulletSpawner.Spawn();
			//}
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			print(other.tag);
			if (other.CompareTag("Enemy"))
				GameManager.Instance.GameOver();
		}
	}
}
