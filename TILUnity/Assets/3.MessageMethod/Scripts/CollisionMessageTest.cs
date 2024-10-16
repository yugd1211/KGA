using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMessageTest : MonoBehaviour
{
	// �������� �浹 �Ǵ� ��ȣ�ۿ뿡 ���ؼ� ȣ��Ǵ� �޼���
	// OnCollisionxxx() �޼��� ȣ�� ���� : ȣ�� �� ������Ʈ�� Collider ������Ʈ�� �����Ǿ� �־�� �Ѵ�.
	// �޽��� �Լ��� ȣ���ϴ� ��ü�� Rigidbody�̴�. �׷��Ƿ� ���� �ϳ��� Rigidbody�� �پ�Ѵ�.


	// 1. OnCollisionEnter : �������� �浹�� �߻����� �� ȣ��Ǵ� �޼��� �Լ�
	private void OnCollisionEnter(Collision collision)
	{
		Collider otherCollider = collision.collider;	// �浹�� �߻��� ���

		print($"�浹 �߻� : {otherCollider.name}");
	}

	// 2. OnCollisionExit : �������� �浹�� ������ �� ȣ��Ǵ� �޼��� �Լ�
	private void OnCollisionExit(Collision collision)
	{
		Collider otherCollider = collision.collider;    // �浹�� �߻��� ���

		print($"�浹�� : {otherCollider.name}");
	}

	// 3. OnCollisionStay : �������� �浹�� ���ӵǴ� ���� ȣ��Ǵ� �޼��� �Լ�
	private void OnCollisionStay(Collision collision)
	{
		Collider otherCollider = collision.collider;    // �浹�� �߻��� ���

		print($"�浹��~~~~~~~~~~~~~~~~~ : {otherCollider.name}");
	}
}
