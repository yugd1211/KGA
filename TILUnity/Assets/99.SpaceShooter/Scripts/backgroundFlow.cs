using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceShooter
{
	public class backgroundFlow : MonoBehaviour
	{
		public float flowSpeed;
		private void Update()
		{
			// transform : �� ������Ʈ�� ������ ������Ʈ�� Transform ������Ʈ
			// Transform.Translate : ���� Position���� �Ķ������ Vector�� ��ŭ �̵�
			transform.Translate(Vector3.down * Time.deltaTime * flowSpeed);
			if (transform.position.y < -2.55f)
				transform.position = Vector3.zero;
		}
	}
}
