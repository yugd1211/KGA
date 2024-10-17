using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTest : MonoBehaviour
{
	// Transform : 씬에 실체를 가진 모든 GameObject들은 무조건 1개의 Transform을 가지고 있음
	public GameObject yourObject;

	public Transform parent;
	public Transform grandParent;

	private void Start()
	{
		// 모든 GameObject, Component는 Transform 프로퍼티를 가지고 있음
		// 해당 객체의 Transform을 반환함
		print($"my transform : {transform}");
		//print($"your transform : {yourObject.transform}");
		// 무한참조 가능
		//print($"{transform.transform.transform.transform.transform.transform.transform.transform.transform.transform.transform.transform.transform.transform}");


		string someChildsName = parent.Find("FirstChild").GetChild(0).name;
		print(someChildsName);
		// SetPrant : 2번째 인자값을 true로 주면, 월드 좌표계를 유지하면서 부모를 변경
		// SetParent : 2번째 인자값을 false로 주면, 로컬 좌표계를 유지하면서 부모를 변경
		parent.SetParent(grandParent, false);
	}
}
