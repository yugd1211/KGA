using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierceCountUp : Skill
{
	public int pierceCount;

	private void Start()
	{
		GameManager.Instance.player.pierceCount += pierceCount;
	}

	private void OnDisable()
	{
		GameManager.Instance.player.pierceCount -= pierceCount;
	}
}
