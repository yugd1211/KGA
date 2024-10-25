using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float hp = 100f;
	public float damage = 10f;
	public float moveSpeed = 5f;
	public Vector2 fireDir;
	public Vector2 moveDir;
	public float fireInterval;
	public bool isFire;

	public Animator IndicatorAnim;
	public Animator anim;
	public SkillSlot[] skillSlots;

	public int Level => level + 1;
	public float Damage { get { return damage * Level; } }
	public int KillCount { get; set; }
	public int TotalKillCount { get; set; }
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
		foreach (SkillSlot skillSlot in skillSlots)
		{
			skillSlot.CreatePrefab(transform);

		}
	}

	private void Start()
	{
		maxHp = hp;
		KillCount = 0;
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
	}

	// 파라미터로 넘어온 스킬의 레벨을 상승시키고 다음레벨의 프리팹으로 교체
	public void OnSkillLevelUp(SkillSlot skillSlot)
	{
		if (skillSlot.skillLevel >= skillSlot.skillPrefabs.Length - 1)
		{
			// 유효하지 않은 스킬
			Debug.LogWarning($"최대 레벨에 도달한 스킬 레벨업을 시도함. {skillSlot.skillName}");
			return;
		}
		skillSlot.skillLevel++;

		skillSlot.CreatePrefab(transform);
		//skillSlot.currentSkillOjbect = Instantiate(skillSlot.skillPrefabs[skillSlot.skillLevel], transform, false);
		//skillSlot.currentSkillOjbect.name = skillSlot.skillPrefabs[skillSlot.skillLevel].name;
		//skillSlot.currentSkillOjbect.transform.localPosition = Vector2.zero;
		//if (skillSlot.isTargeting)
		//{
		//skill.currentSkillOjbect.transform.SetParent(fireDir);
		//}
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
			OnLevelUp();
		}
	}

	private void OnLevelUp()
	{
		level++;
		UIManager.Instance.levelupPanel.gameObject.SetActive(true);
		UIManager.Instance.levelupPanel.LevelUpPanelOpen(skillSlots.ToList(), OnSkillLevelUp);
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent<Item>(out Item item))
		{
			item.Contact();
		}

		// 특정 클래스를 상속하지 않고, 공통점이 없는 여러 객체들이 경우에 따라 같은 행동을 해야 할 경우
		// Interface를 사용할 수 있다.
		//if (collision.TryGetComponent<IContactable>(out IContactable contactable))
		//{
		//	contactable.Contact();
		//}

		// 게임 오브젝트는 모두 SendMessage를 통해 가지고 있는 컴포넌트의 특정 이름을 가진 함수를 호출하도록 하는 기능을 지원한다.	
		//collision.SendMessage("Contact", SendMessageOptions.DontRequireReceiver);
		// SendMessage 사용시 주의점
		// 1. 문자열로 함수를 호출하므로 함수 이름 변경 또는 오타 발생 시 에러 찾기가 힘들다.
		// 2. 해당 객체에 있는 모든 컴포넌트들이 Contact라는 함수를 가지고 있는지 탐색을 수행하기 때문에 퍼포먼스가 효율적이라고 보기 힘들다.
		// 3. 호출할 함수의 파라미터는 0개 또는 1개로 제한된다. 
	}

}
