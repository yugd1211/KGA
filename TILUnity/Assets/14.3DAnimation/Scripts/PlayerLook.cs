using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
	public Transform cameraRig;
	public float mouseSensivity;

	private float rigAngle = 0f;
	private void Update()
	{
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = Input.GetAxis("Mouse Y");
		// 마우?�의 좌우 ?�직임??맞춰 캐릭?�의 Transform???�전?�킨??
		transform.Rotate(0, mouseX * mouseSensivity * Time.deltaTime, 0);

		rigAngle -= mouseY * mouseSensivity * Time.deltaTime;
		rigAngle = Mathf.Clamp(rigAngle, -90f, 90f);
		cameraRig.localEulerAngles = new Vector3(rigAngle, 0, 0);
	}
}
