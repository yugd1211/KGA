using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectFindTest : MonoBehaviour
{
	// ������ ���� �Ǳ� �� ������ ������ �� �ִ� ������Ʈ�� Inspecter â���� �Ҵ��Ͽ� ���� �� �� �ִ�.
	public GameObject target;
	// ������ ������ ���۵Ǳ� ���� ���� �� �� ���ų�, Inspecterâ���� ���� �Ҵ��� �� ���� ��ü�� ���
	private GameObject privateTarget;

	private GameObject findedTarget;

	private GameObject newTarget;


	private void Start()
	{
		// privateTarget�� ã�� ���
		// 1. ��ü ������ �̸��� Ÿ������ ã�´�.
		// ���� ������Ʈ�� �������� ������尡 Ŀ����.
		// ���� �̸��� ������Ʈ�� ������ ���� ��� � ������Ʈ�� Ž������ Ȯ���� �� ����.
		// ���� ���� ������ Start()�Լ������� ���������� ���δ�.
		privateTarget = GameObject.Find("PrivateTarget");

		//2. ��ü ������ Ư�� ������Ʈ�� ������ �ִ� ��ü�� ã�´�.
		//findedTarget = (FindObjectOfType(typeof(FindMe)) as Component).gameObject;
		findedTarget = FindObjectOfType<FindMe>().gameObject;

		//3. ��ü�� �����ϰ� �ش� ��ü�� ������ �����ϴ� ���

		newTarget = new GameObject();
		newTarget = new GameObject("NewTarget");
		newTarget = new GameObject("component Attached GameObject", typeof(FindMe), typeof(SpriteRenderer));


		// 4. Distroy()�Լ��� �̿��Ͽ� ��ü�� �����Ѵ�.
		//Destroy(target);
		// 2��° ���ڴ� �� �� �ڿ� ���������� ��Ÿ����.
		//Destroy(target, 2f);
		//print(findedTarget.name);

	}
}
