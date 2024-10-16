using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
	public int intVar = 1;
	public float floatVar= 0.1f;
	public bool boolVar = true;

	public short shortVar = short.MaxValue;
	public ushort ushortVar = ushort.MaxValue;
	public long longVar = long.MaxValue;
	public ulong ulongVar = ulong.MaxValue;
	public decimal decVar = decimal.MaxValue;

	public char charVar = 'A';
	public string strVar = "Hello World";

	private void Start()
	{
		Debug.Log(intVar);
		Debug.Log(strVar);
	}

	private void Update()
	{
		
	}

	private void Reset()
	{
		strVar = "Unity";
	}
}
