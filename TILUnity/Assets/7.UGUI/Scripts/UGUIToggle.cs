using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGUIToggle : MonoBehaviour
{
	public void OnValueChange(bool isOn)
	{
		print($"{name} ��� ���� : {isOn}");
	}
}
