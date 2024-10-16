using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageMethodTest : MonoBehaviour
{
	// 메세지 함수(이벤트 함수) : 개발자가 직접 호출하지 않아도 유니티 게임 프로세스상 발생하는 이벤트에 따라 유니티 엔진이 호출해주는 힘수
	// 함수 이름이 정해져 있으며, 함수 종류마다 호출 조건이 다르다.
	private BoxCollider boxCollider;

	// 0. Awake : 게임이 로드된 후, 가장 첫 프레임 시작 직전에 호출된다.
	// 해당 GameObject 내의 다른 컴포넌트는 접근 가능하지만, 다른 GameObject는 아직 로드가 안되어서 접근이 불가능 할 가능성이 있다.
	// 이 컴포넌트가 부착된 게임 오브젝트를 초기화 할 용도로 사용
	private void Awake()
	{
		boxCollider = GetComponent<BoxCollider>();

		if (transform.position.y > 1)
		{
			boxCollider.center = new Vector3(0, -1, 0);
		}
		print("Awake 메서드 함수 호출");
	}

	// 1. Start : 게임이 로드된 후, 가장 첫 프레임 시작 직전에 호출된다.
	private string state;
	private bool isInit = false;
	private void Start()
	{
		print("Start 메서드 함수 호출");
		state = "준비 완료";
		isInit = true;
	}


	// 2. Update : 게임이 로드된 후, 매 프레임마다 한번씩 호출된다.
	private void Update()
	{
		//Start();
	}

	// 3. OnEnable/ OnDisable : 해당 객체 또는 컴포넌트가 활성화 되거나 비활성화 되면 호출 
	// OnEnable은 객체 로드가 완료된 후에 즉시 호출 되므로, 처음 1회 Start보다 먼저 호출된다.
	// 컴포넌트의 초기화 수행 여부를 체크 해주면 좋다.
	private void OnEnable()
	{
		if (isInit == false)
			return; 
		print("활성화 ");
	}

	private void OnDisable()
	{
		print("비활성화 ");
	}

	// 4. OnDestroy : 해당 객체가 삭제되기 직전에 호출된다.
	// OnDestroy보다 OnDisable이 먼저 호출된다.
	private void OnDestroy()
	{
		print("으아아아아아아");
	}
}
