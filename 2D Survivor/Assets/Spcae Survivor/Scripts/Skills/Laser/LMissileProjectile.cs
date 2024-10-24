using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LMissileProjectile : MonoBehaviour
{
	public float damage;
	public float moveSpeed;
	public float duration;

	CircleCollider2D coll;

	private Transform rendererTransform;

	public Vector2 rendererStartPos; // 폭탄이 생성됐을 때, sprite renderer가 있을 위치(local pos)

	private void Awake()
	{
		coll = GetComponent<CircleCollider2D>();
		coll.enabled = false;
		rendererTransform = transform.Find("Renderer");
	}
	private void Start()
	{
		_ = StartCoroutine(Explosion());
	}


	private IEnumerator Explosion()
	{
		float startTime = Time.time;
		float endTime = startTime + duration;
		rendererTransform.localPosition = rendererStartPos;
		// 도트데미지
		while (startTime < endTime)
		{
			yield return null;
			float currentTime = Time.time - startTime;  // currentTime 갱신
			float t = currentTime / duration;
			startTime = Time.time;
			Vector2 curRendpos = Vector2.Lerp(rendererStartPos, Vector2.zero, t);

			// 위치 갱신
			rendererStartPos = rendererTransform.localPosition = curRendpos;

			print(curRendpos);
			//rendererTransform.localPosition = curRendpos;
			//foreach (Collider2D coll in colls)
			//{
			//	if (coll.CompareTag("Enemy"))
			//	{
			//		print($"Exloded collider :{coll.name}");
			//	}
			//}
		}


		// 마지막 폭발
		Collider2D[] contactedColl = Physics2D.OverlapCircleAll(transform.position, coll.radius);
		foreach (Collider2D coll in contactedColl)
		{
			if (coll.CompareTag("Enemy"))
			{
				print($"Exloded collider :{coll.name}");
			}
		}

		Destroy(gameObject);
	}
	// 생성된 위치에서 일정 시간 후에 범위 내의 적에게 데미지를 주고 사라짐

}
