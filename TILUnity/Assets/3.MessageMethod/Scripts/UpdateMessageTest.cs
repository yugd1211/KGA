using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMessageTest : MonoBehaviour
{


	//1. Update : 매 프레임의 가장 처음 호출
	private float preFrameTime = 0; // 이전 프레임이 호출된 시간
	private void Update()
	{
		// 게임이 시작된 뒤로 1초당 1f의 속도로 누적
		print($"Update 호출됨. 호출 시간 :{Time.time}, 이전 프레임과 시간 차이 : {Time.time - preFrameTime}");
		preFrameTime = Time.time;

		print($"deltaTime :{Time.deltaTime}");
	}

	// FixedUpdate : 게임 로직과 별개로 물리연산이 수행될 때마다 호출, 호출 주기가 일정함
	private float prePhysicsFrameTime = 0;
	private void FixedUpdate()
	{
		print($"FixedUpdate 호출됨. 호출 시간 :{Time.time}, 이전 프레임과 시간 차이 : {Time.time - prePhysicsFrameTime}");
		prePhysicsFrameTime = Time.time;

		print($"fixedDeltaTime :{Time.fixedDeltaTime}");
	}

	// 3. LateUpdate : Update가 호출된 후에 호출
	private float preFrameLateTime = 0;
	private void LateUpdate()
	{
		print($"LateUpdate 호출됨. 호출 시간 :{Time.time}, 이전 프레임과 시간 차이 : {Time.time - preFrameLateTime}");
		preFrameLateTime = Time.time;
	}
}
