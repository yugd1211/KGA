using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
	private PostProcessVolume _volume;

	public float grainSize;

	private Grain grainEffect;

	private void Awake()
	{
		_volume = GetComponent<PostProcessVolume>();
	}

	private void Start()
	{
		grainEffect = _volume.profile.GetSetting<Grain>();
	}

	private void Update()
	{
		grainEffect.size.Override(grainSize);
	}
}
