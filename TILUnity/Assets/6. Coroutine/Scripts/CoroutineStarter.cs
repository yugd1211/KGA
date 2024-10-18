using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineStarter : MonoBehaviour
{
	public CoroutineTarget target;

	private void Start()
	{
		// 코루틴의 주체가 중요하다.
		// 코루틴을 시작하는 객체가 비활성화, 파괴될시 코루틴이 중지된다.

		// StartCoroutine 호출시 코루틴을 핸들링하는 객체가 나 자신이 되므로
		// 내 게임 오브젝트가 비활성화 되거나 Component가 비활성화 되면 자신이 StartCoroutine을 통해 생성한 모든 코루틴도 동작을 멈춤

		target.StartCoroutine(DamageOnTime());
		//StartCoroutine(DamageOnTime());
	}

	private IEnumerator DamageOnTime()
	{
		print($"{name}이 {target.name}에게 중독을 입혔습니다.");

		for (int i = 0; i < 10; i++)
		{
			yield return new WaitForSeconds(1.0f);
			print($"{target.name} : 데미지를 받았습니다. x {i}");
		}
	}
}
