using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCountUp : Skill
{
	public int projectileCount = 0;
	private void Start() 
	{
		GameManager.Instance.player.projectileCount += projectileCount;
	}

	private void OnDisable()
	{
		GameManager.Instance.player.projectileCount -= projectileCount;
	}
}
