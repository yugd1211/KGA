using UnityEngine;

public class EnemyStateIdle : AState<EnemyAgentController>
{
	public EnemyStateIdle(EnemyAgentController owner) : base(owner) { }

	private int currentTarget = 0;
	
	private bool SearchPlayer(out PlayerAgentController player)
	{
		Collider[] hitColliders = Physics.OverlapSphere(owner.transform.position, owner.chaseDistance, LayerMask.GetMask("Player"));
		foreach (Collider hitCollider in hitColliders)
		{
			if (hitCollider.TryGetComponent(out player))
			{
				return true;
			}
		}

		player = null;
		return false;
	}
	
	public override void OnUpdate()
	{
		if (SearchPlayer(out PlayerAgentController player))
			owner.ChangeState(new EnemyStateChase(owner, player));
		else
		{
			if (owner.targets.Length == 0)
				return;
			owner.SetDestination(owner.targets[currentTarget].position);

			float dis = (owner.transform.position - owner.targets[currentTarget].position).magnitude;
			if (dis < 0.1f)
				currentTarget = (currentTarget + 1) % owner.targets.Length;
		}
	}

	public override void OnEnter()
	{
		currentTarget = 0;
	}

	public override void OnExit()
	{
	}
}
