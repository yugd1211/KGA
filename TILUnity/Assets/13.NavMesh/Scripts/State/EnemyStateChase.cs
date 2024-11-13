using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateChase : AState<EnemyAgentController>
{
    public PlayerAgentController player;

    public EnemyStateChase(EnemyAgentController owner, PlayerAgentController player) : base(owner)
    {
        this.player = player;
    }

    private bool AttackRangeToPlayer()
    {
        Collider[] hitColliders = Physics.OverlapSphere(owner.transform.position, 0.5f, LayerMask.GetMask("Player"));
        if (hitColliders.Length > 0)
            return true;
        return false;
    }
    public override void OnUpdate()
    {
        if (player == null)
            return;
        owner.SetDestination(player.transform.position);
        
        float dis = (player.transform.position - owner.transform.position).magnitude;
        if (dis > owner.chaseDistance)
        {
            owner.ChangeState(new EnemyStateReturn(owner));
        }
        if (AttackRangeToPlayer())
            owner.ChangeState(new EnemyStateAttack(owner, player));
    }
    
    public override void OnEnter()
    {
    }

    public override void OnExit()
    {
        player = null;
    }
}
