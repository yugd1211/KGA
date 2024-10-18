using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class PhysicsTest : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpped;
    public float jumpPower;
	private Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	private void Update()
    {
        float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");


		rb.MovePosition(transform.position + new Vector3(x, 0, z) * moveSpped * Time.deltaTime);
		// ���� ������ �Ͼ�� �������� Update���� �̵��� ��ġ�� ������ �Ͼ�� ���� �������� ���� Rigidbody�� ���� ����
		//transform.Translate(new Vector3(x, 0, z) * moveSpped * Time.deltaTime
		
		if(Input.GetButtonDown("Jump"))
		{
			rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);

			// ���� ���Ҷ� AddForce �Լ��� ���
			// ForceMode
			//					�߷� ����		�߷� ����
			// ���ӵ� �߰�		.Force			.Acceleration
			// ��� �߰�		.Impulse		.VelocityChange

			// rb.AddTorque();			// ȸ��
			// rb.angularVelocity		// ȸ�� ���
			// rb.maxAngularVelocity	// �ִ� ȸ�� ����� ����
			// rb.maxLinearVelocity		// �ִ� ���� ����� ����
			// rb.Drag					// (����)����
			// rb.angularDrag			// ȸ�� ����
			// rb.automatic Center Of Mass // ���� �߽� �ڵ� ����(�ڽİ� �θ� ������Ʈ�� �߰�)
			// rb.isKinematic			// ���� ������ ���� ����
		}

		// Phiysics.Raycast();		// ����ĳ��Ʈ

		if (Input.GetButtonDown("Fire1"))
		{
			Ray ray = new Ray(transform.position , Vector3.forward);
			Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 1f);
			// ���� (+z ����)�� �ִ� �ݶ��̴��� �����ؼ� ���� Enemy�±װ� ������ ���ְ����
			if (Physics.Raycast(ray ,out RaycastHit hit,  10, 1 << LayerMask.NameToLayer("Default")))
			{
				print($"�ݶ��̴� ���� : {hit.collider.name}");
				if (hit.collider.CompareTag("Enemy"))
				{
					Destroy(hit.collider.gameObject);
				}
			}
		
		}

	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Enemy"))
		{
			rb.AddForce(Vector3.back * 5f, ForceMode.Impulse);
			// Enemy �±׸� ���� ������Ʈ�� �浹�ϸ� -z �������� ƨ���.
		}
	}

	//private void FixedUpdate()
	//{
	//	float x = Input.GetAxis("Horizontal");
	//	float z = Input.GetAxis("Vertical");

	//	// InputManager�� ���� �Է� ó���� �Ұ��
	//	// ��� �Է� ó���� Update���� �̷������ ������
	//	// FixedUpdate������ ��Ȯ�� ������ �˱� ��ƴ�.
	//	//if (Input.GetButtonDown("Jump"))
	//	//{
	//		//transform.Translate(Vector3.up);
	//	//}


	//	//transform.Translate(new Vector3(x, 0, z) * moveSpped * Time.deltaTime);

	//}
}
