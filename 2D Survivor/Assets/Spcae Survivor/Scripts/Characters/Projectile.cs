using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float damage;
	public float moveSpeed;
	public float duration;
	public ParticleSystem impactParticle;

	public int pierceCount = 0;


	private CircleCollider2D coll;

	private void Awake()
	{
		coll = GetComponent<CircleCollider2D>();
		coll.enabled = false;
	}

	private void OnEnable()
	{
		StartCoroutine(PushDelay(duration));
	}


	List<Collider2D> contactedColls = new List<Collider2D>();
	// OverlapCircle 함수를 통해 감지한 적이 있는 콜라이더를 담을 List

	private void Update()
	{
		Move(Vector2.up);

		Collider2D contactedColl = Physics2D.OverlapCircle(transform.position, coll.radius);
		if (contactedColl && contactedColl.CompareTag("Enemy"))
		{
			if (contactedColls.Contains(contactedColl) == false)
			{
				// 유효타 발생
				contactedColls.Add(contactedColl);
				pierceCount--;
				contactedColl.GetComponent<Enemy>()?.TakeDamage(damage);
				if (pierceCount == 0)
				{
					ProjectilePool.pool.Push(this);
				}
			}
		}
	}

	public void Move(Vector2 dir)
	{
		transform.Translate(dir * moveSpeed * Time.deltaTime);
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.CompareTag("Enemy"))
		{
			other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
			Bounds myBound = GetComponent<Collider2D>().bounds;
			ParticleSystem p = Instantiate(impactParticle, transform.position, Quaternion.identity);
			p.Play();
			Destroy(p.gameObject, 1f);
			Destroy(gameObject);
		}
	}
	private IEnumerator PushDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		PoolManager.Instance.projectilePool.Push(this);
		//ProjectilePool.pool.Push(this);
	}

	private void OnDisable()
	{
		contactedColls.Clear();
	}
}
