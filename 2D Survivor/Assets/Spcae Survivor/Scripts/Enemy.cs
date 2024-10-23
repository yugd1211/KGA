using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public float hp = 100f;
	public float damage = 10f;
	public float moveSpeed = 3f;
	public float attackRate = 1f;
	public Image hpBar;
	public Player player;

	public float hpAmount { get { return hp / maxHp; } }
	private float maxHp;

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
		//print(moveDir.magnitude); // vector.magnitude : 해당 벡터가 "방향벡터"로 간주될 때, 벡터의 길이를 반환
	}

	private void Move(Vector2 dir)
	{
		// dir을 단위벡터로 변환 해줘야 함
		// dir이 단위벡터가 아닌 길이 까지 담겨있을 경우 해당 벌어지는 길이만큼의 벡터가 담기기 때문에 속도가 다르더라도 두 객체간 거리는 멀어지지 않음
		transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);
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

	private Coroutine attackCoroutine;

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.CompareTag("Player"))
			attackCoroutine = StartCoroutine(AttackCoroutine(other.transform.GetComponent<Player>()));

	}

	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.transform.CompareTag("Player"))
			StopCoroutine(attackCoroutine);
	}


	private IEnumerator AttackCoroutine(Player player)
	{
		while (true)
		{
			player.TakeDamage(damage);
			yield return new WaitForSeconds(attackRate);
		}
	}

}
