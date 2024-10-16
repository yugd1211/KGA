using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTest : MonoBehaviour
{
	public GameObject destroyTarget;
	public Component destroyComponentTarget;
	public GameObject destroyTargetWithDelay;
	public GameObject destroyTargetOnImmediately;


	// 객체 제거하는 방법
	private void Start()
	{
		// 1. GameObject를 Destroy한다.
		Destroy(destroyTarget);
		// 2. Component를 비롯한 Object를 Destroy한다.
		Destroy(destroyComponentTarget);
		// Destroy 함수는 호출 이후에도 파라미터로 전달한 오브젝트에 참조가 가능 (객체가 아직 파괴되지 않는다)
		FindMe findMe = destroyComponentTarget as FindMe;
		print(findMe.message);
		// Destroy 함수는 오브젝트를 즉시 파괴하는 것이 아닌 파괴 리스트에 추가하고, 다음 프레임에 파괴한다.
		// 따라서, Destroy 함수 호출 이후에도 오브젝트에 접근이 가능하다.

		// 3. 그렇기 때문에, Destroy 함수는 딜레이를 설정 하는 것이 가능하다.
		Destroy(destroyTargetWithDelay, 3.0f);

		// 4. 만약 같은 프레임이라도 특정 객체가 즉시 파괴되기를 원한다면 DestroyImmediate() 함수를 사용한다.
		DestroyImmediate(destroyTargetOnImmediately);
		// 이 함수가 호출된 이후의 코드라인 에서는 해당 객체를 참조할 수 없다.
		print(destroyTargetOnImmediately);


	}
}
