using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UGUIDropdown : MonoBehaviour
{
	public Image dropdownImage;
	public void OnValueChange(int value)
	{
		print($"��Ӵٿ� �� �ٲ� :{value}");
	}
}
