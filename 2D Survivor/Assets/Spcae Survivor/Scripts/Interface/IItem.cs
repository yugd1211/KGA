using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
	enum ItemType
	{
		Potion,
		Bomb,
		Exp
	}
	public abstract void Contact();
}

