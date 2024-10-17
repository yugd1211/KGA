using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformControlTest : MonoBehaviour
{
	public Transform target;
	// 기본적으로 Transform의 Position, Rotation, localScale 프로퍼티를 통해 해당 오브젝트의 위치, 각도, 크기등을 제어할 수 있다.


	private void Start()
	{
		//ControlStraightly();
		ControlByMethod();
	}

	private void ControlStraightly()
	{
		transform.position = new Vector3(1, 2, 3);
		transform.rotation = Quaternion.Euler(30, 20, 10);
		transform.localScale = new Vector3(4, 5, 6);
	}

	//방향 (상, 하, 좌, 우, 전, 후)에 방향 벡터를 대입하여 Rotation 제어
	private void ControlByDirection()
	{
		Vector3 dirVec = target.position - transform.position;

		transform.forward = dirVec;
		transform.up = dirVec;
		transform.right = dirVec;
		transform.up = -dirVec;
		transform.right = -dirVec;
		transform.forward = -dirVec;
	}

	private void ControlByMethod()
	{
		// Translate : 해당 방향으로 이동(Position)
		transform.Translate(5, 0, 0);
		// Rotate : 해당 방향으로 회전(Rotation)
		transform.Rotate(30, 0, 0);

		//Translate, Rotate 함수를 사용하여 제어하는 것은
		// transform.position, rotation에 값을 직접 할당하는 것과 비교하자면
		// 현재 position, rotation 기준으로 상대적인 연산이 이루어지는것이다.
	}


	private void Update()
	{
		//transform.position = transform.position + new Vector3(3, 2, 1) * Time.deltaTime;
		//transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(10, 20, 30) * Time.deltaTime);
		transform.Translate(new Vector3(3, 2, 1) * Time.deltaTime);
		transform.Rotate(new Vector3(10, 20, 30) * Time.deltaTime);
	}

}
