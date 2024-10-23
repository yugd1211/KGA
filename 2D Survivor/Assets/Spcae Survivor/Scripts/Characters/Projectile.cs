using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float damege;
	public float moveSpeed;
	public float duration;
	public ParticleSystem impactParticle;


	private void Awake()
	{
	}

	private void Start()
	{
		Destroy(gameObject, duration);
	}

	private void Update()
	{
		Move(Vector2.up);
	}


	public void Move(Vector2 dir)
	{
		transform.Translate(dir * moveSpeed * Time.deltaTime);
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.CompareTag("Enemy"))
		{
			other.gameObject.GetComponent<Enemy>().TakeDamage(damege);
			Bounds myBound = GetComponent<Collider2D>().bounds;
			ParticleSystem p = Instantiate(impactParticle, transform.position, Quaternion.identity);
			p.Play();
			Destroy(p.gameObject, 1f);
			Destroy(gameObject);
		}
	}
}
