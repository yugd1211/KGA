using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformControlTest : MonoBehaviour
{
	public Transform target;
	// �⺻������ Transform�� Position, Rotation, localScale ������Ƽ�� ���� �ش� ������Ʈ�� ��ġ, ����, ũ����� ������ �� �ִ�.


	private void Start()
	{
		//ControlStraightly();
		ControlByMethod();
	}

	private void ControlStraightly()
	{
		transform.position = new Vector3(1, 2, 3);
		transform.rotation = Quaternion.Euler(30, 20, 10);
		transform.localScale = new Vector3(4, 5, 6);
	}

	//���� (��, ��, ��, ��, ��, ��)�� ���� ���͸� �����Ͽ� Rotation ����
	private void ControlByDirection()
	{
		Vector3 dirVec = target.position - transform.position;

		transform.forward = dirVec;
		transform.up = dirVec;
		transform.right = dirVec;
		transform.up = -dirVec;
		transform.right = -dirVec;
		transform.forward = -dirVec;
	}

	private void ControlByMethod()
	{
		// Translate : �ش� �������� �̵�(Position)
		transform.Translate(5, 0, 0);
		// Rotate : �ش� �������� ȸ��(Rotation)
		transform.Rotate(30, 0, 0);

		//Translate, Rotate �Լ��� ����Ͽ� �����ϴ� ����
		// transform.position, rotation�� ���� ���� �Ҵ��ϴ� �Ͱ� �����ڸ�
		// ���� position, rotation �������� ������� ������ �̷�����°��̴�.
	}


	private void Update()
	{
		//transform.position = transform.position + new Vector3(3, 2, 1) * Time.deltaTime;
		//transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(10, 20, 30) * Time.deltaTime);
		transform.Translate(new Vector3(3, 2, 1) * Time.deltaTime);
		transform.Rotate(new Vector3(10, 20, 30) * Time.deltaTime);
	}

}
