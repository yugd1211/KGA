using System;
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
	public float interval;
	public int projectileCount;
	public int pierceCount;

	public Animator IndicatorAnim;
	public Animator anim;
	public SkillSlot[] skillSlots;

	public int Level => level + 1;

	public float Damage => damage;
	// public float Damage { get { return damage * Level; } }
	public int KillCount { get; set; }
	public int TotalKillCount { get; set; }
	public float hpAmount { get { return hp / maxHp; } }

	public int exp = 0;
	private int level = 0;
	private List<int> levelupSteps = new List<int> { 100, 300, 500, 800, 1200 }; // �ִ� ���� 5
	private int currentMaxExp => levelupSteps[level];
	private float maxHp;
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

		// ���� ����� ���� ��ġ�� �޾� ������ ����
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
	}
	private void FixedUpdate()
	{
		Move(moveDir);
	}

	// �Ķ���ͷ� �Ѿ�� ��ų�� ������ ��½�Ű�� ���������� ���������� ��ü
	public void OnSkillLevelUp(SkillSlot skillSlot)
	{
		if (skillSlot.skillLevel >= skillSlot.skillPrefabs.Length - 1)
		{
			// ��ȿ���� ���� ��ų
			Debug.LogWarning($"�ִ� ������ ������ ��ų �������� �õ���. {skillSlot.skillName}");
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
	///	Transform�� ���� ���� ������Ʈ�� �����̴� �Լ�
	/// </summary>
	/// <param name="dir">�̵� ����</param>
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
			// �ش� �ִϸ��̼��� �������̸� Ʈ���Ÿ� �߻���Ű�� ����
			//AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
			//if (info.IsName("Hit") == false)

			// ����� �ǰݾִϸ��̼� -> �ǰݾִϸ��̼����� ���� Transition�� HitTrigger�� �����߰� HasExitTime�� üũ �����ؼ� Hit�ϸ� �ٷιٷ�
			// �ش� �ִϸ��̼��� ����ǰԲ� �ߴ�.
			anim.SetTrigger("Hit");
		}
	}

	public void Die()
	{
		// GameManager�� ����
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
		if (level >= levelupSteps.Count)
		{
			int lastLevel = level - 1;
			levelupSteps.Add(levelupSteps[lastLevel] + levelupSteps[lastLevel] - levelupSteps[lastLevel - 1] + 100);
		}
		if (level < levelupSteps.Count && this.exp >= currentMaxExp)
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

		// Ư�� Ŭ������ ������� �ʰ�, �������� ���� ���� ��ü���� ��쿡 ���� ���� �ൿ�� �ؾ� �� ���
		// Interface�� ����� �� �ִ�.
		//if (collision.TryGetComponent<IContactable>(out IContactable contactable))
		//{
		//	contactable.Contact();
		//}

		// ���� ������Ʈ�� ��� SendMessage�� ���� ������ �ִ� ������Ʈ�� Ư�� �̸��� ���� �Լ��� ȣ���ϵ��� �ϴ� ����� �����Ѵ�.	
		//collision.SendMessage("Contact", SendMessageOptions.DontRequireReceiver);
		// SendMessage ���� ������
		// 1. ���ڿ��� �Լ��� ȣ���ϹǷ� �Լ� �̸� ���� �Ǵ� ��Ÿ �߻� �� ���� ã�Ⱑ �����.
		// 2. �ش� ��ü�� �ִ� ��� ������Ʈ���� Contact��� �Լ��� ������ �ִ��� Ž���� �����ϱ� ������ �����ս��� ȿ�����̶�� ���� �����.
		// 3. ȣ���� �Լ��� �Ķ���ʹ� 0�� �Ǵ� 1���� ���ѵȴ�. 
	}

}
