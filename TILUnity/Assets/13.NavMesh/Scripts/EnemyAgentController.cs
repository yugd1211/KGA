using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAgentController : MonoBehaviour
{
	public Vector3 startPosition;
	public FSM<EnemyAgentController> fsm { get; private set; }
	public float moveSpeed = 2f;
	public float chaseDistance = 10f;

	public Transform[] targets;
	
	private NavMeshAgent agent;

	public void ChangeState(AState<EnemyAgentController> state)
	{
		fsm.TransitionState(state);
	}
	
	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
		fsm = new FSM<EnemyAgentController>(this);
		fsm.TransitionState(new EnemyStateIdle(this));
		startPosition = transform.position;
	}

	public void SetDestination(Vector3 pos)
	{
		agent.speed = moveSpeed;
		agent.SetDestination(pos);
	}

	private void Update()
	{
		fsm.Update();
	}
}
