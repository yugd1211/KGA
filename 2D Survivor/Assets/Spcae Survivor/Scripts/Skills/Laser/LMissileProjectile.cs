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

	public Vector2 rendererStartPos; // ��ź�� �������� ��, sprite renderer�� ���� ��ġ(local pos)

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
		// ��Ʈ������
		while (startTime < endTime)
		{
			yield return null;
			float currentTime = Time.time - startTime;  // currentTime ����
			float t = currentTime / duration;
			startTime = Time.time;
			Vector2 curRendpos = Vector2.Lerp(rendererStartPos, Vector2.zero, t);

			// ��ġ ����
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


		// ������ ����
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
	// ������ ��ġ���� ���� �ð� �Ŀ� ���� ���� ������ �������� �ְ� �����

}
