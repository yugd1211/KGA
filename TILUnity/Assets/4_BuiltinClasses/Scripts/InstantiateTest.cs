using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTest : MonoBehaviour
{
	public GameObject original;

	private void Start()
	{
		GameObject clone;
		clone = Instantiate(original, Vector3.right, original.transform.rotation, transform);
		//Instantiate �Լ��� �Ű����� ��ü�� �����Ѵ�.
		// clone = Instantiate(original, Vector3.right, Quaternion.identity, transform);
		clone.name = "clone~~~~~~~~~~~~~~~~~~~~~";

		clone.GetComponent<MeshRenderer>().material.color = Color.gray;
	}
}
