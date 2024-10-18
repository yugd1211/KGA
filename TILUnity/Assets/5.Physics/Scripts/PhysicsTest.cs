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
		// 물리 연산이 일어나는 시점에서 Update에서 이동한 위치와 간섭이 일어나면 다음 프레임의 값이 Rigidbody에 의해 변함
		//transform.Translate(new Vector3(x, 0, z) * moveSpped * Time.deltaTime
		
		if(Input.GetButtonDown("Jump"))
		{
			rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);

			// 힘을 가할때 AddForce 함수를 사용
			// ForceMode
			//					중량 적용		중량 무시
			// 가속도 추가		.Force			.Acceleration
			// 운동량 추가		.Impulse		.VelocityChange

			// rb.AddTorque();			// 회전
			// rb.angularVelocity		// 회전 운동량
			// rb.maxAngularVelocity	// 최대 회전 운동량을 제한
			// rb.maxLinearVelocity		// 최대 직선 운동량을 제한
			// rb.Drag					// (공기)저항
			// rb.angularDrag			// 회전 저항
			// rb.automatic Center Of Mass // 질량 중심 자동 설정(자식과 부모 오브젝트의 중간)
			// rb.isKinematic			// 물리 연산을 하지 않음
		}

		// Phiysics.Raycast();		// 레이캐스트

		if (Input.GetButtonDown("Fire1"))
		{
			Ray ray = new Ray(transform.position , Vector3.forward);
			Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 1f);
			// 전방 (+z 방향)에 있는 콜라이더를 감지해서 만약 Enemy태그가 있으면 없애고싶음
			if (Physics.Raycast(ray ,out RaycastHit hit,  10, 1 << LayerMask.NameToLayer("Default")))
			{
				print($"콜라이더 감지 : {hit.collider.name}");
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
			// Enemy 태그를 가진 오브젝트와 충돌하면 -z 방향으로 튕긴다.
		}
	}

	//private void FixedUpdate()
	//{
	//	float x = Input.GetAxis("Horizontal");
	//	float z = Input.GetAxis("Vertical");

	//	// InputManager를 통한 입력 처리를 할경우
	//	// 모든 입력 처리는 Update에서 이루어지기 때문에
	//	// FixedUpdate에서는 정확한 시점을 알기 어렵다.
	//	//if (Input.GetButtonDown("Jump"))
	//	//{
	//		//transform.Translate(Vector3.up);
	//	//}


	//	//transform.Translate(new Vector3(x, 0, z) * moveSpped * Time.deltaTime);

	//}
}
