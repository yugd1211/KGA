using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectFindTest : MonoBehaviour
{
	// 게임이 시작 되기 전 씬에서 참조할 수 있는 오브젝트는 Inspecter 창에서 할당하여 참조 할 수 있다.
	public GameObject target;
	// 하지만 게임이 시작되기 전에 참조 할 수 없거나, Inspecter창에서 값을 할당할 수 없는 객체의 경우
	private GameObject privateTarget;

	private GameObject findedTarget;

	private GameObject newTarget;


	private void Start()
	{
		// privateTarget을 찾는 방법
		// 1. 전체 씬에서 이름을 타겟으로 찾는다.
		// 씬에 오브젝트가 많을수록 오버헤드가 커진다.
		// 같은 이름의 오브젝트가 여러개 있을 경우 어떤 오브젝트가 탐색될지 확신할 수 없다.
		// 위와 같은 이유로 Start()함수에서만 제한적으로 쓰인다.
		privateTarget = GameObject.Find("PrivateTarget");

		//2. 전체 씬에서 특정 컴포넌트를 가지고 있는 객체를 찾는다.
		//findedTarget = (FindObjectOfType(typeof(FindMe)) as Component).gameObject;
		findedTarget = FindObjectOfType<FindMe>().gameObject;

		//3. 객체를 생성하고 해당 객체의 참조를 유지하는 방식

		newTarget = new GameObject();
		newTarget = new GameObject("NewTarget");
		newTarget = new GameObject("component Attached GameObject", typeof(FindMe), typeof(SpriteRenderer));


		// 4. Distroy()함수를 이용하여 객체를 삭제한다.
		//Destroy(target);
		// 2번째 인자는 몇 초 뒤에 삭제할지를 나타낸다.
		//Destroy(target, 2f);
		//print(findedTarget.name);

	}
}
