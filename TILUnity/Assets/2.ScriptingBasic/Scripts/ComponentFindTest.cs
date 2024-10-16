using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentFindTest : MonoBehaviour
{
	// 타겟 게임 오브젝트는 알지만, 해당 오브젝트가 가진 특정 컴포넌트를 찾는 경우
	public GameObject target;

	private FindMe findMe;

	private void Start()
	{
		// target 오브젝트에서 FindMe 컴포넌트를 찾는다.
		findMe = target.GetComponent<FindMe>();

		print(findMe.message);

		bool isFinded = target.TryGetComponent<BoxCollider>(out BoxCollider box);
		if (isFinded)
		{
			print($"Box Collider를 찾았습니다. :) {box}");
		}
		else
		{
			print($"Box Collider를 찾지 못했습니다. :( {box}");
		}

		FindMe newFindMe = target.AddComponent<FindMe>();
		newFindMe.message = "새로운 으흐흐";

		FindMe[] child = target.GetComponentsInChildren<FindMe>();
		foreach (FindMe c in child)
		{
			print(c.message);
		}

		Destroy(findMe.gameObject, 2f);

	}
}
