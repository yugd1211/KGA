using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ShaderTest : MonoBehaviour
{
	private new Renderer renderer;

	public float ColorMultiplier { get; set; } = 1.0f;
	public float timeSpeed;

	private void Awake()
	{
		renderer = GetComponent<Renderer>();
	}

	private void Update()
	{
		float timeSin = Mathf.Sin(Time.time * timeSpeed * Mathf.Deg2Rad);
		timeSin = Mathf.Abs(timeSin);
		renderer.material.SetFloat("_ColorMultiple", timeSin);
	}

	// private void OnValueChange(float value)
	// {
	// 	colorMultiplier = value;
	// }
}
