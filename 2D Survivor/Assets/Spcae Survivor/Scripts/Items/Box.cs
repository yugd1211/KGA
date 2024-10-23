using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Box : MonoBehaviour
{
	public GameObject item;
	private void Contact()
	{
		Instantiate(item, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
