using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
	public float hp = 100f;
	public float damage = 10f;
	public float moveSpeed = 5f;
	public float attackSpeed = 0.3f;
	public Projectile projectilePrefab;
	public Vector2 fireDir;
	public Vector2 moveDir;


	public float Damage { get { return damage * Level; } }
	public int KillCount { get; set; }
	public float hpAmount { get { return hp / maxHp; } }
	public float Exp
	{
		get
		{
			return exp;
		}
		set
		{
			exp = value;
			if (exp >= 100)
			{
				exp -= 100;
				level++;
			}
		}
	}

	private float exp;
	public int Level => level;
	private int level = 1;


	private float maxHp;
	private Coroutine fireCoroutine;


	private void Awake()
	{
		maxHp = hp;
		KillCount = 0;
	}

	private void Start()
	{
		GameManager.Instance.player = this;
	}

	private void Update()
	{
		if (Time.timeScale <= 0)
			return;
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");


		if (x != 0 || y != 0)
			moveDir = new Vector2(x, y);


		// 마우스의 위치를 받아 방향을 정함
		//Vector2 mouseScreenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//fireDir = mouseScreenPos - (Vector2)transform.position;


		Enemy targetEnemy = null;
		float minDistance = float.MaxValue;
		// 제일 가까운 적의 위치를 받아 방향을 정함
		foreach (Enemy enemy in GameManager.Instance.enemies)
		{
			float distance = Vector3.Distance(transform.position, enemy.transform.position);
			if (distance < minDistance)
			{
				minDistance = distance;
				targetEnemy = enemy;
			}
		}
		if (targetEnemy != null)
			fireDir = targetEnemy.transform.position - transform.position;


		Move(moveDir);
		if (Input.GetButtonDown("Fire1"))
		{
			fireCoroutine = StartCoroutine(FireCoroutine());
		}
		else if (Input.GetButtonUp("Fire1"))
		{
			StopAllCoroutines();
		}
	}

	private IEnumerator FireCoroutine()
	{
		// Vector3 -> Vector2로 묵시적 변환 가능 : z값 생략
		while (true)
		{
			Fire(fireDir);
			yield return new WaitForSeconds(attackSpeed);
		}
	}


	/// <summary>
	///	Transform을 통해 게임 오브젝트를 움직이는 함수
	/// </summary>
	/// <param name="dir">이동 방향</param>
	public void Move(Vector2 dir)
	{
		transform.Translate(dir * moveSpeed * Time.deltaTime);
	}


	/// <summary>
	/// 투사체를 발사하는 함수
	/// </summary>
	public void Fire(Vector2 dir)
	{
		Projectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
		projectile.damege = Damage;
		projectile.duration = 5f;
		projectile.moveSpeed = 10f;
		projectile.transform.up = dir;
	}

	public void TakeDamage(float damage)
	{
		hp -= damage;
		if (hp <= 0)
			Die();
	}

	public void Die()
	{
		// GameManager의 역할
		// Time.timeScale = 0;
		// Destroy(gameObject);
	}

	public void Heal(float amount)
	{
		hp += amount;
		if (hp > maxHp)
			hp = maxHp;
	}
}
