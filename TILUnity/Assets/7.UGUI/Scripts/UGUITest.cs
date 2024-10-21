using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UGUITest : MonoBehaviour
{
	public Image image;
	public TextMeshProUGUI tmp;

	private void Start()
	{
		image.color = Color.black;
		tmp.text = "Hello UGUI";
	}
}
