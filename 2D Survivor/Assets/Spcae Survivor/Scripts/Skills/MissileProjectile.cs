using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MissileProjectile : MonoBehaviour
{
	public float damage;
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
		// lineRenderer = GetComponent<LineRenderer>();
		// DrawCircleOutline();
		_ = StartCoroutine(Explosion());
	}
	//
	// public float radius = 5f;     // 원의 반지름
	// public int segmentCount = 50; // 원을 구성할 점의 개수 (값이 클수록 더 부드러운 원이 됨)
	// private LineRenderer lineRenderer;
	//
	// void DrawCircleOutline()
	// {
	// 	// LineRenderer 설정
	// 	lineRenderer.positionCount = segmentCount + 1; // 마지막 점이 처음 점과 연결되도록 +1
	// 	lineRenderer.loop = true;                      // 라인이 원형으로 닫히도록 설정
	//
	// 	// 각 점의 위치 계산
	// 	for (int i = 0; i <= segmentCount; i++)
	// 	{
	// 		float angle = i * (360f / segmentCount) * Mathf.Deg2Rad;
	// 		float x = Mathf.Cos(angle) * radius;
	// 		float y = Mathf.Sin(angle) * radius;
	// 		lineRenderer.SetPosition(i, new Vector3(x, y, 0));
	// 	}
	// }

	private IEnumerator Explosion()
	{
		float startTime = Time.time;
		float endTime = startTime + duration;
		rendererTransform.localPosition = rendererStartPos;
		while (Time.time < endTime)
		{
			yield return null;
			float t = (Time.time - startTime) / duration;
    
			Vector2 curRendpos = Vector2.Lerp(rendererStartPos, Vector2.zero, t);
			rendererTransform.localPosition = curRendpos;
		}


		Collider2D[] contactedColl = Physics2D.OverlapCircleAll(transform.position, coll.radius);
		foreach (Collider2D coll in contactedColl)
		{
			if (coll.CompareTag("Enemy") && coll.TryGetComponent<Enemy>(out Enemy enemy))
			{
				enemy.TakeDamage(damage);
			}
		}

		Destroy(gameObject);
	}
	// ������ ��ġ���� ���� �ð� �Ŀ� ���� ���� ������ �������� �ְ� �����

}
