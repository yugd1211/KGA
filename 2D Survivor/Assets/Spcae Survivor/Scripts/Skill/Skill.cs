using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
	public float interval;
	public abstract void UseSkill(Transform target);
}
