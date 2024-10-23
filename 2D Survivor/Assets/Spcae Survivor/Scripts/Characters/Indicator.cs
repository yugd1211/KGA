using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
	public enum targetType
	{
		Move,
		Attack
	}
	public targetType type;

	private void Update()
	{
		if (type == targetType.Attack)
		{
			//Vector2 mouseScreenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//Vector2 attackDir = mouseScreenPos - (Vector2)transform.position;
			transform.up = GameManager.Instance.player.fireDir;
		}
		else if (type == targetType.Move)
		{
			//float x = Input.GetAxis("Horizontal");
			//float y = Input.GetAxis("Vertical");
			//transform.up = new Vector2(x, y);
			transform.up = GameManager.Instance.player.moveDir;
		}
	}
}
