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
			// transform : 이 컴포넌트가 부착된 오브젝트의 Transform 컴포넌트
			// Transform.Translate : 현재 Position에서 파라미터의 Vector값 만큼 이동
			transform.Translate(Vector3.down * Time.deltaTime * flowSpeed);
			if (transform.position.y < -2.55f)
				transform.position = Vector3.zero;
		}
	}
}
