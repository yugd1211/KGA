using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
	public float hp = 100f;
	public float damage = 10f;
	public float moveSpeed = 5f;
	public Projectile projectilePrefab;
	public Vector2 fireDir;
	public Vector2 moveDir;
	public float fireInterval;
	public bool isFire;

	public Animator IndicatorAnim;
	public Animator anim;




	public Skill skill;



	public int Level => level + 1;
	public float Damage { get { return damage * Level; } }
	public int KillCount { get; set; }
	public float hpAmount { get { return hp / maxHp; } }

	public int exp = 0;
	private int level = 0;
	private int[] levelupSteps = { 100, 300, 500, 800, 1200 }; // 최대 레벨 5
	private int currentMaxExp => levelupSteps[level];
	// 현재 레벨에서 레벨업 하기까지 필요한 경험치량
	private float maxHp;
	//private Coroutine fireCoroutine;
	private Rigidbody2D rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		//s = gameObject.AddComponent<LaserShotgun>();
		//s = gameObject.AddComponent<LaserGun>();
		//skill.interval = fireInterval;
		Skill s = Instantiate(skill);
		s.transform.SetParent(transform);
	}

	private void Start()
	{
		maxHp = hp;
		KillCount = 0;
		GameManager.Instance.player = this;
		// 리턴이 있는 함수를 호출할 때 리턴을 받아주지 않는다면
		// 반환을 위한 메모리를 점유하지 않고 함수만 호출하게 하는 기능 "_=" 
		//_ = StartCoroutine(FireCoroutine());
	}

	private void Update()
	{
		if (Time.timeScale <= 0)
			return;
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");


		if (x != 0 || y != 0)
			moveDir = new Vector2(x, y);
		IndicatorAnim.SetBool("isMoving", moveDir.magnitude > 0.6f);

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
		// 마우스 좌클릭 또는 왼쪾 ctrl키로 발사
		if (Input.GetButton("Fire1"))
		{
			if (targetEnemy != null)
			{
				print($"Player {targetEnemy.GetInstanceID()}");
				// todo : 현재 코루틴을 ㅗ처리하니까 변수 캡처때문에 문제있음
				skill.UseSkill(targetEnemy.transform);
			}
			//isFire = true;
			//fireCoroutine = StartCoroutine(FireCoroutine());
		}
		//else if (Input.GetButtonUp("Fire1"))
		//{
		//	isFire = false;
		//	//StopAllCoroutines();
		//}

		// 적이 없으면 발사 금지
		//if (GameManager.Instance.enemies.Count == 0)
		//	isFire = false;
	}





	/// <summary>
	///	Transform을 통해 게임 오브젝트를 움직이는 함수
	/// </summary>
	/// <param name="dir">이동 방향</param>
	public void Move(Vector2 dir)
	{
		//transform.Translate(dir * moveSpeed * Time.deltaTime);
		Vector2 movePos = rb.position + (dir * moveSpeed * Time.deltaTime);
		rb.MovePosition(movePos);
	}


	//private IEnumerator FireCoroutine()
	//{
	//	// Vector3 -> Vector2로 묵시적 변환 가능 : z값 생략
	//	while (true)
	//	{
	//		//if (isFire)
	//		//Fire(fireDir);
	//		yield return new WaitForSeconds(fireInterval);
	//	}
	//}

	/// <summary>
	/// 투사체를 발사하는 함수
	/// </summary>
	//public void Fire(Vector2 dir)
	//{
	//	Projectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
	//	projectile.damage = Damage;
	//	projectile.duration = 5f;
	//	projectile.moveSpeed = 10f;
	//	projectile.transform.up = dir;
	//}

	public void TakeDamage(float damage)
	{
		hp -= damage;
		if (hp <= 0)
		{
			Die();
		}
		else
		{
			// 해당 애니메이션이 진행중이면 트리거를 발생시키지 않음
			//AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
			//if (info.IsName("Hit") == false)

			// 현재는 피격애니메이션 -> 피격애니메이션으로 가는 Transition을 HitTrigger로 설정했고 HasExitTime을 체크 해제해서 Hit하면 바로바로
			// 해당 애니메이션이 실행되게끔 했다.
			anim.SetTrigger("Hit");
		}
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

	public void GainExp(int exp)
	{
		this.exp += exp;
		if (level < levelupSteps.Length && this.exp >= currentMaxExp)
		{
			LevelUp();
			// 레벨업 이펙트도 추가해야함
			// 레벨업 UI도 띄워줘야함
			// 그러니까 함수로 뺴자
		}
	}

	private void LevelUp()
	{
		level++;
		GameManager.Instance.TimeStop();
		GameManager.Instance.LevelUpUi.SetActive(true);
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		//if (collision.TryGetComponent<Item>(out Item item))
		//{
		//	item.Contact();
		//}

		// 특정 클래스를 상속하지 않고, 공통점이 없는 여러 객체들이 경우에 따라 같은 행동을 해야 할 경우
		// Interface를 사용할 수 있다.
		//if (collision.TryGetComponent<IContactable>(out IContactable contactable))
		//{
		//	contactable.Contact();
		//}

		// 게임 오브젝트는 모두 SendMessage를 통해 가지고 있는 컴포넌트의 특정 이름을 가진 함수를 호출하도록 하는 기능을 지원한다.	
		collision.SendMessage("Contact", SendMessageOptions.DontRequireReceiver);
		// SendMessage 사용시 주의점
		// 1. 문자열로 함수를 호출하므로 함수 이름 변경 또는 오타 발생 시 에러 찾기가 힘들다.
		// 2. 해당 객체에 있는 모든 컴포넌트들이 Contact라는 함수를 가지고 있는지 탐색을 수행하기 때문에 퍼포먼스가 효율적이라고 보기 힘들다.
		// 3. 호출할 함수의 파라미터는 0개 또는 1개로 제한된다. 
	}

}
