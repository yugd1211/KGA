using UnityEngine;
using UnityEngine.AI;

// 없으면 자동으로 해당 컴포넌트 부착해줌
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerAgentController : MonoBehaviour
{
	public float moveSpeed = 5f;
	public Transform pointer;
	public NavMeshAgent agent;

	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	public void TakeDamage(float amount)
	{
		Debug.Log($"PlayerAgentController TakeDamage : {amount}");
	}
	
	private void Start()
	{
		pointer.position = transform.position;
	}

	private void Update()
	{
		agent.speed = moveSpeed;
		// AI에게 특정 지점으로 이동하도록 하는 함수
		agent.SetDestination(pointer.position);
		agent.isStopped = isStop;
	}

	public bool isStop;
}
