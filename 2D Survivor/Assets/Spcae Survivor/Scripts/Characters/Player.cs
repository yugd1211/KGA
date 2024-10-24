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
	private int[] levelupSteps = { 100, 300, 500, 800, 1200 }; // �ִ� ���� 5
	private int currentMaxExp => levelupSteps[level];
	// ���� �������� ������ �ϱ���� �ʿ��� ����ġ��
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
		// ������ �ִ� �Լ��� ȣ���� �� ������ �޾����� �ʴ´ٸ�
		// ��ȯ�� ���� �޸𸮸� �������� �ʰ� �Լ��� ȣ���ϰ� �ϴ� ��� "_=" 
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


		Move(moveDir);
		// ���콺 ��Ŭ�� �Ǵ� �ަU ctrlŰ�� �߻�
		if (Input.GetButton("Fire1"))
		{
			if (targetEnemy != null)
			{
				print($"Player {targetEnemy.GetInstanceID()}");
				// todo : ���� �ڷ�ƾ�� ��ó���ϴϱ� ���� ĸó������ ��������
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

		// ���� ������ �߻� ����
		//if (GameManager.Instance.enemies.Count == 0)
		//	isFire = false;
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


	//private IEnumerator FireCoroutine()
	//{
	//	// Vector3 -> Vector2�� ������ ��ȯ ���� : z�� ����
	//	while (true)
	//	{
	//		//if (isFire)
	//		//Fire(fireDir);
	//		yield return new WaitForSeconds(fireInterval);
	//	}
	//}

	/// <summary>
	/// ����ü�� �߻��ϴ� �Լ�
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
		if (level < levelupSteps.Length && this.exp >= currentMaxExp)
		{
			LevelUp();
			// ������ ����Ʈ�� �߰��ؾ���
			// ������ UI�� ��������
			// �׷��ϱ� �Լ��� ����
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

		// Ư�� Ŭ������ ������� �ʰ�, �������� ���� ���� ��ü���� ��쿡 ���� ���� �ൿ�� �ؾ� �� ���
		// Interface�� ����� �� �ִ�.
		//if (collision.TryGetComponent<IContactable>(out IContactable contactable))
		//{
		//	contactable.Contact();
		//}

		// ���� ������Ʈ�� ��� SendMessage�� ���� ������ �ִ� ������Ʈ�� Ư�� �̸��� ���� �Լ��� ȣ���ϵ��� �ϴ� ����� �����Ѵ�.	
		collision.SendMessage("Contact", SendMessageOptions.DontRequireReceiver);
		// SendMessage ���� ������
		// 1. ���ڿ��� �Լ��� ȣ���ϹǷ� �Լ� �̸� ���� �Ǵ� ��Ÿ �߻� �� ���� ã�Ⱑ �����.
		// 2. �ش� ��ü�� �ִ� ��� ������Ʈ���� Contact��� �Լ��� ������ �ִ��� Ž���� �����ϱ� ������ �����ս��� ȿ�����̶�� ���� �����.
		// 3. ȣ���� �Լ��� �Ķ���ʹ� 0�� �Ǵ� 1���� ���ѵȴ�. 
	}

}
