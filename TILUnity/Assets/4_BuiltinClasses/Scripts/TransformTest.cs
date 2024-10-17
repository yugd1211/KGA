using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTest : MonoBehaviour
{
	// Transform : ���� ��ü�� ���� ��� GameObject���� ������ 1���� Transform�� ������ ����
	public GameObject yourObject;

	public Transform parent;
	public Transform grandParent;

	private void Start()
	{
		// ��� GameObject, Component�� Transform ������Ƽ�� ������ ����
		// �ش� ��ü�� Transform�� ��ȯ��
		print($"my transform : {transform}");
		//print($"your transform : {yourObject.transform}");
		// �������� ����
		//print($"{transform.transform.transform.transform.transform.transform.transform.transform.transform.transform.transform.transform.transform.transform}");


		string someChildsName = parent.Find("FirstChild").GetChild(0).name;
		print(someChildsName);
		// SetPrant : 2��° ���ڰ��� true�� �ָ�, ���� ��ǥ�踦 �����ϸ鼭 �θ� ����
		// SetParent : 2��° ���ڰ��� false�� �ָ�, ���� ��ǥ�踦 �����ϸ鼭 �θ� ����
		parent.SetParent(grandParent, false);
	}
}
