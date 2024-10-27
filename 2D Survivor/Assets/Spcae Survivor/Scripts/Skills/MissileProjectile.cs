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
		_ = StartCoroutine(Explosion());
	}

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
				enemy.TakeDamage(damage);
		}
		PoolManager.Instance.Remove(this);
	}
	// ������ ��ġ���� ���� �ð� �Ŀ� ���� ���� ������ �������� �ְ� �����

}
