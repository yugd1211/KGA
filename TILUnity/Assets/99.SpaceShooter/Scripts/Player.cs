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
			// Input : InputManager�� ����� Ȱ���Ͽ� �Է� ó���� �� �� �ִ� Ŭ����
			// Input.GetAxis() // �̸� ���ǵǾ��ִ� �Է� ���� ���� �����´�.
			// Horizontal : x��, Vertical : y��
		
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
