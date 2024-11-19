using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class SizeAttribute : Attribute
{
	public float scale;
	
	public SizeAttribute(float scale)
	{
		this.scale = scale;
	}
}
