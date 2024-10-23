using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.ParticleSystem;

public class Enemy : MonoBehaviour
{
	public float hp = 100f;
	public float damage = 10f;
	public float moveSpeed = 3f;
	public float damageInterval = 1f;
	public Image hpBar;
	public Player player;
	public ParticleSystem impactParticle;

	public float hpAmount { get { return hp / maxHp; } }
	private float maxHp;
	private Rigidbody2D rb;
	private Coroutine attackCoroutine;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Start()
	{
		maxHp = hp;
		player = GameManager.Instance.player;
		GameManager.Instance.enemies.Add(this);
		GameManager.Instance.enemyAllKillEvent += Die;
	}

	private void Update()
	{
		Vector2 moveDir = player.transform.position - transform.position;
		moveDir = moveDir.normalized;
		// image의 imagetype이 filled여야 가능한 필드
		hpBar.fillAmount = hpAmount;
		Move(moveDir);
	}
	private void Move(Vector2 dir)
	{

		Vector2 movePos = rb.position + (dir * moveSpeed * Time.deltaTime);
		rb.MovePosition(movePos);
	}

	public void TakeDamage(float damage)
	{
		hp -= damage;
		if (hp <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
		GameManager.Instance.enemies.Remove(this);
		GameManager.Instance.enemyAllKillEvent -= Die;
		GameManager.Instance.player.KillCount++;
		GameManager.Instance.itemSpawner.SpawnExp(transform.position);
		Destroy(gameObject);
	}


	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.CompareTag("Player"))
		{
			var particle = Instantiate(impactParticle, other.GetContact(0).point, Quaternion.identity);
			particle.Play();
			Destroy(particle.gameObject, 2f);
			attackCoroutine = StartCoroutine(AttackCoroutine(other));
		}

	}

	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.transform.CompareTag("Player"))
			StopCoroutine(attackCoroutine);
	}


	private IEnumerator AttackCoroutine(Collision2D target)
	{
		while (true)
		{
			player.TakeDamage(damage);
			yield return new WaitForSeconds(damageInterval);
		}
	}

}
