using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class Planet : MonoBehaviour
{
	private Solar solar;
	public float rotateSpeed = 10.0f;

	public GameObject revolveTarget;
	public float revolveDistance = 10.0f;
	public float revolveSpeed = 10.0f;
	private float revolveTime = 0.0f;

	private float targetScale;

	private void Start()
	{
		solar = FindObjectOfType<Solar>();
		targetScale = revolveTarget.transform.localScale.x;
		revolveSpeed = revolveSpeed * 24 * 60 * 60;
		rotateSpeed = rotateSpeed * 24 * 60 * 60;
		transform.Rotate(Vector3.up, 10f);
	}

	void FixedUpdate()
    {
		// ����
		//float rotationSpeed = 86,400f;  // ���� �ֱ� (��)
		//rotationTime += (Time.fixedDeltaTime * (2 * Mathf.PI) / rotationSpeed);
		transform.position = revolveTarget.transform.position + new Vector3(targetScale / 2, 0, 0);
		transform.position = transform.position + new Vector3(revolveDistance * solar.disdanceMag, 0, 0);
		//transform.Rotate(Vector3.up, (Time.fixedDeltaTime * (2 * Mathf.PI) / rotateSpeed));
		transform.Rotate(Vector3.up, 360 * Time.fixedTime / rotateSpeed);

		// if (gameObject.name == "Earth")
			// print(360 * Time.fixedTime / rotateSpeed);

		// ����
		revolveTime += (Time.fixedDeltaTime * (2 * Mathf.PI) / revolveSpeed);
		float x = (targetScale / 2 + revolveDistance * solar.disdanceMag) * Mathf.Cos(revolveTime);
		float z = (targetScale / 2 + revolveDistance * solar.disdanceMag) * Mathf.Sin(revolveTime);
		transform.position = new Vector3(x, transform.position.y, z);
		if (gameObject.name == "Moon")
		{
			print($"{targetScale}, {revolveDistance}, {solar.disdanceMag}");
		}

	}
}
