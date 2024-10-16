using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentFindTest : MonoBehaviour
{
	// Ÿ�� ���� ������Ʈ�� ������, �ش� ������Ʈ�� ���� Ư�� ������Ʈ�� ã�� ���
	public GameObject target;

	private FindMe findMe;

	private void Start()
	{
		// target ������Ʈ���� FindMe ������Ʈ�� ã�´�.
		findMe = target.GetComponent<FindMe>();

		print(findMe.message);

		bool isFinded = target.TryGetComponent<BoxCollider>(out BoxCollider box);
		if (isFinded)
		{
			print($"Box Collider�� ã�ҽ��ϴ�. :) {box}");
		}
		else
		{
			print($"Box Collider�� ã�� ���߽��ϴ�. :( {box}");
		}

		FindMe newFindMe = target.AddComponent<FindMe>();
		newFindMe.message = "���ο� ������";

		FindMe[] child = target.GetComponentsInChildren<FindMe>();
		foreach (FindMe c in child)
		{
			print(c.message);
		}

		Destroy(findMe.gameObject, 2f);

	}
}
