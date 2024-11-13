using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateReturn :  AState<EnemyAgentController>
{
    public EnemyStateReturn(EnemyAgentController owner) : base(owner) { }

    public override void OnUpdate()
    {
        owner.SetDestination(owner.startPosition);
        if ((owner.transform.position - owner.startPosition).sqrMagnitude < 0.01f)
        {
            owner.ChangeState(new EnemyStateIdle(owner));
        }
        // throw new System.NotImplementedException();
    }

    public override void OnEnter()
    {
        // throw new System.NotImplementedException();
    }

    public override void OnExit()
    {
        // throw new System.NotImplementedException();
    }
}
