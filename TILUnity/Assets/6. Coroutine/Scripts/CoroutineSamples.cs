using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineSamples : MonoBehaviour
{
	private void Start()
	{
		//StartCoroutine(ReturnNull());
		//StartCoroutine(ReturnWaitForSeconds(1.0f, 5));
		//StartCoroutine(ReturnWaitForSecondsRealtime(1.0f, 5));
		//StartCoroutine(ReturnUntilAndWhile());
		//StartCoroutine(ReturnFrames());
		StartCoroutine(_1st());
	}

	// yield return null : 매 프레임마다 다음 yield return을 반환
	private IEnumerator ReturnNull()
    {
        print("Return Null Coroutine Start");
        while (true)
        {
		    yield return null;
            print($"Return null Coroutine~~~~~~~~~~~~~~~~~~~~~ {Time.time}");
        }
	}

	// yield return new WaitForSeconds(파라미터) : 코루틴이 yield return을 만나면 파라미터만큼 대기 후 수행
	private IEnumerator ReturnWaitForSeconds(float interval, int count)
	{
		print("Return WaitForSeconds Coroutine Start");
		for (int i = 0; i < count; i++)
		{
			yield return new WaitForSeconds(interval);
			print($"Return WaitForSeconds Coroutine~~~~~~~~~~~~~~~~~~~~~ {Time.time}");
		}
		print("Return WaitForSeconds Coroutine End");
	}


	// yield return new WaitForSecondsRealtime(파라미터) : 실제 시간을 기준으로 대기
	// WaitForSeconds와 동작은 같으나 TimeScale에 영향 받지 않는다.
	//WaitForSeconds는 Time.TimeScale에 영향을 받는다.
	private IEnumerator ReturnWaitForSecondsRealtime(float interval, int count)
	{
		print("Return WaitForSecondsRealtime Coroutine Start");
		for (int i = 0; i < count; i++)
		{
			yield return new WaitForSecondsRealtime(interval);
			print($"Return WaitForSecondsRealtime Coroutine~~~~~~~~~~~~~~~~~~~~~ {Time.time}");
		}
		print("Return WaitForSecondsRealtime Coroutine End");
	}

	public bool continueKey;
	private bool IsContinue()
	{
		return continueKey;
	}

	// yield return new WaitUntil / WaitWhile(param) : 특정 조건이 True/False가 될때까지 대기
	private IEnumerator ReturnUntilAndWhile()
	{
		print("Return Until Wihle 코루틴 시작");
		while (true)
		{
			//yield return new WaitUntil(IsContinue);
			// new WaitUntil : 매개변수로 넘어간 함수(대리자)의 return이 false인 동안 대기, true면 넘어감(프레임마다 확인)
			yield return new WaitUntil(() => continueKey);
			print("컨티뉴 키가 참됨");

			// new WaitWhile : 매개변수로 넘어간 함수(대리자)의 return이 true인 동안 대기, false면 넘어감
			yield return new WaitWhile(() => continueKey);
			print("컨티뉴 키가 거짓됨");
		}
	}


	// yield return new (Frame 계열) : 인 게임의 특정 프레임 뒤에 수행됨
	private IEnumerator ReturnFrames()
	{
		// EndOfFrame : 모든 렌더링이 끝난 후(마지막)까지 기다림 (LateUpdate보다 늦게 호출)
		yield return new WaitForEndOfFrame();
		print("EndOfFrame");
		isFirstFrame = false;
	}

	private IEnumerator ReturnFixedUpdate()
	{
		// FixedUpdate : 물리연산이 끝날 때까지 기다림
		yield return new WaitForFixedUpdate();
	}

	bool isFirstFrame = true;
	
	private void Update()
	{
		if (isFirstFrame)
		{
			//print("Update 메시지 함수 호출");
		}
	}

	private void LateUpdate()
	{
		if (isFirstFrame)
		{
			//print("LateUpdate 메시지 함수 호출");
		}
	}


	//yield return 코루틴 : 해당 코루틴이 끝날때까지 대기
	private IEnumerator _1st()
	{
		print("1번째 코루틴 start");
		for(int i = 0; i < 5; i++)
		{
			yield return new WaitForSeconds(1.0f);
			print($"1번째 코루틴 {i + 1}번째 수행중");
		}
		// 코루틴이지만 동기적으로 수행됨
		print("1번째 코루틴 2번째 코루틴 시작하고 대기");
		yield return StartCoroutine(_2nd());
		print("1번째 코루틴 end");
	}

	Coroutine _3rdCoroutine;

	private IEnumerator _2nd()
	{
		print("2번째 코루틴 start");
		print("2번 코루틴이 3번째 코루틴 시작하고 대기");
		_3rdCoroutine =  StartCoroutine(_3rd());
		yield return _3rdCoroutine; 
		for (int i = 0; i <5; i++)
		{
			print($"2번째 코루틴{i + 1}번째 수행중");
			yield return new WaitForSeconds(1.0f);
		}
		print("2번째 코루틴 end");
	}
	private IEnumerator _3rd() 
	{
		print("3번째 코루틴 start");
		for (int i = 0; i <5; i++)
		{
			print($"3번째 코루틴 {i + 1}번째 수행중");
			yield return new WaitForSeconds(1.0f);
		}
		print("3번째 코루틴 end");
	}

}