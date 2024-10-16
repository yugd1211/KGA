using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageMethodTest : MonoBehaviour
{
	// �޼��� �Լ�(�̺�Ʈ �Լ�) : �����ڰ� ���� ȣ������ �ʾƵ� ����Ƽ ���� ���μ����� �߻��ϴ� �̺�Ʈ�� ���� ����Ƽ ������ ȣ�����ִ� ����
	// �Լ� �̸��� ������ ������, �Լ� �������� ȣ�� ������ �ٸ���.
	private BoxCollider boxCollider;

	// 0. Awake : ������ �ε�� ��, ���� ù ������ ���� ������ ȣ��ȴ�.
	// �ش� GameObject ���� �ٸ� ������Ʈ�� ���� ����������, �ٸ� GameObject�� ���� �ε尡 �ȵǾ ������ �Ұ��� �� ���ɼ��� �ִ�.
	// �� ������Ʈ�� ������ ���� ������Ʈ�� �ʱ�ȭ �� �뵵�� ���
	private void Awake()
	{
		boxCollider = GetComponent<BoxCollider>();

		if (transform.position.y > 1)
		{
			boxCollider.center = new Vector3(0, -1, 0);
		}
		print("Awake �޼��� �Լ� ȣ��");
	}

	// 1. Start : ������ �ε�� ��, ���� ù ������ ���� ������ ȣ��ȴ�.
	private string state;
	private bool isInit = false;
	private void Start()
	{
		print("Start �޼��� �Լ� ȣ��");
		state = "�غ� �Ϸ�";
		isInit = true;
	}


	// 2. Update : ������ �ε�� ��, �� �����Ӹ��� �ѹ��� ȣ��ȴ�.
	private void Update()
	{
		//Start();
	}

	// 3. OnEnable/ OnDisable : �ش� ��ü �Ǵ� ������Ʈ�� Ȱ��ȭ �ǰų� ��Ȱ��ȭ �Ǹ� ȣ�� 
	// OnEnable�� ��ü �ε尡 �Ϸ�� �Ŀ� ��� ȣ�� �ǹǷ�, ó�� 1ȸ Start���� ���� ȣ��ȴ�.
	// ������Ʈ�� �ʱ�ȭ ���� ���θ� üũ ���ָ� ����.
	private void OnEnable()
	{
		if (isInit == false)
			return; 
		print("Ȱ��ȭ ");
	}

	private void OnDisable()
	{
		print("��Ȱ��ȭ ");
	}

	// 4. OnDestroy : �ش� ��ü�� �����Ǳ� ������ ȣ��ȴ�.
	// OnDestroy���� OnDisable�� ���� ȣ��ȴ�.
	private void OnDestroy()
	{
		print("���ƾƾƾƾƾ�");
	}
}
