using UnityEngine;

public class EnemyStateAttack : AState<EnemyAgentController>
{
	public PlayerAgentController player;

	public EnemyStateAttack(EnemyAgentController owner, PlayerAgentController player) : base(owner)
	{
		this.player = player;
	}

	public override void OnUpdate()
	{
		player.TakeDamage(1);
		owner.ChangeState(new EnemyStateChase(owner, player));
	}
	
	public override void OnEnter()
	{
	}

	public override void OnExit()
	{
		player = null;
	}
}
