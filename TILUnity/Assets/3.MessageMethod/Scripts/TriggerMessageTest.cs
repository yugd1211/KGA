using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMessageTest : MonoBehaviour
{
	// Collider ������Ʈ�� IsTrigger �Ӽ��� True�� ������ ������ �������� �浹�� ����Ű�� �ʴ� ��� Coliider ���� ���� �ٸ� collider�� ��ȣ �ۿ��� �����ϴ�.
	// OnCollisionxx �޼��� �Լ��� ���������� �� ��ü �� �ϳ��� �ݵ�� Rigidbody ������Ʈ�� �־�� �Ѵ�.

	// 1. OnTriggerEnter : Collider ���� ���� �ٸ� Collider�� ������ �� ȣ��Ǵ� �޼��� �Լ�
	private void OnTriggerEnter(Collider other)
	{
		print($"Ʈ��������  ȣ�� ��ü : {name},  ��� : {other.name}");
	}

	// 2. OnTriggerExit : Collider ���� ���� �ٸ� Collider�� ������ �� ȣ��Ǵ� �޼��� �Լ�
	private void OnTriggerExit(Collider other)
	{
		print($"Ʈ���ų���  ȣ�� ��ü : {name},  ��� : {other.name}");
	}

	// 3. OnTriggerStay : Collider ���� ���� �ٸ� Collider�� �ӹ��� �ִ� ���� ȣ��Ǵ� �޼��� �Լ�
	private void OnTriggerStay(Collider other)
	{
		print($"Ʈ������~~~~~~~~~  ȣ�� ��ü : {name},  ��� : {other.name}");
	}

}
