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
		// image�� imagetype�� filled���� ������ �ʵ�
		hpBar.fillAmount = hpAmount;
		Move(moveDir);
		//print(moveDir.magnitude); // vector.magnitude : �ش� ���Ͱ� "���⺤��"�� ���ֵ� ��, ������ ���̸� ��ȯ
	}

	private void Move(Vector2 dir)
	{
		// dir�� �������ͷ� ��ȯ ����� ��
		// dir�� �������Ͱ� �ƴ� ���� ���� ������� ��� �ش� �������� ���̸�ŭ�� ���Ͱ� ���� ������ �ӵ��� �ٸ����� �� ��ü�� �Ÿ��� �־����� ����
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
