using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : BaseState
{
    protected Animator     _animator;
    protected GameObject   _npc;
    protected NavMeshAgent _agent;
    protected Transform    _transform;
    protected EnemyData    _enemyData;

    public EnemyController(GameObject pNpc, NavMeshAgent pAgent, Animator pAnimator, Transform pEnemy)
    {
        _npc        = pNpc;
        _agent      = pAgent;
        _animator   = pAnimator;
        _transform  = pEnemy;
        stateEvent  = Enums.StateEvent.AWAKE;
    }
}

public class Idle : EnemyController
{
    public Idle(GameObject pNpc, NavMeshAgent pAgent, Animator pAnimator, Transform pEnemy) : base(pNpc, pAgent, pAnimator, pEnemy)
    {
        currentState = Enums.States.Idle;
    }

    public override void StateAwake()
    {
        base.StateAwake();
    }

    public override void StateStart()
    {
        base.StateStart();
    }

    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    public override void StateLateUpdate()
    {
        base.StateLateUpdate();
    }

    public override void StateExit()
    {
        base.StateExit();
    }
}

public class Move : EnemyController
{
    public Move(GameObject pNpc, NavMeshAgent pAgent, Animator pAnimator, Transform pEnemy) : base(pNpc, pAgent, pAnimator, pEnemy)
    {
        currentState = Enums.States.Move;
    }

    public override void StateAwake()
    {
        base.StateAwake();
    }

    public override void StateStart()
    {
        base.StateStart();
    }

    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    public override void StateLateUpdate()
    {
        base.StateLateUpdate();
    }

    public override void StateExit()
    {
        base.StateExit();
    }
}

public class Patrol : EnemyController
{
    public Patrol(GameObject pNpc, NavMeshAgent pAgent, Animator pAnimator, Transform pEnemy) : base(pNpc, pAgent, pAnimator, pEnemy)
    {
        currentState= Enums.States.Patrol;
    }

    public override void StateAwake()
    {
        base.StateAwake();
    }

    public override void StateStart()
    {
        base.StateStart();
    }

    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    public override void StateLateUpdate()
    {
        base.StateLateUpdate();
    }

    public override void StateExit()
    {
        base.StateExit();
    }
}

public class Pursue : EnemyController
{
    public Pursue(GameObject pNpc, NavMeshAgent pAgent, Animator pAnimator, Transform pEnemy) : base(pNpc, pAgent, pAnimator, pEnemy)
    {
        currentState = Enums.States.Pursue;
    }

    public override void StateAwake()
    {
        base.StateAwake();
    }

    public override void StateStart()
    {
        base.StateStart();
    }

    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    public override void StateLateUpdate()
    {
        base.StateLateUpdate();
    }

    public override void StateExit()
    {
        base.StateExit();
    }
}

public class Attack : EnemyController
{
    public Attack(GameObject pNpc, NavMeshAgent pAgent, Animator pAnimator, Transform pEnemy) : base(pNpc, pAgent, pAnimator, pEnemy)
    {
        currentState = Enums.States.Attack;
    }

    public override void StateAwake()
    {
        base.StateAwake();
    }

    public override void StateStart()
    {
        base.StateStart();
    }

    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    public override void StateLateUpdate()
    {
        base.StateLateUpdate();
    }

    public override void StateExit()
    {
        base.StateExit();
    }
}

public class Damaged : EnemyController
{
    public Damaged(GameObject pNpc, NavMeshAgent pAgent, Animator pAnimator, Transform pEnemy) : base(pNpc, pAgent, pAnimator, pEnemy)
    {
        currentState = Enums.States.Damaged;
    }

    public override void StateAwake()
    {
        base.StateAwake();
    }

    public override void StateStart()
    {
        base.StateStart();
    }

    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    public override void StateLateUpdate()
    {
        base.StateLateUpdate();
    }

    public override void StateExit()
    {
        base.StateExit();
    }
}

public class Groggy : EnemyController
{
    public Groggy(GameObject pNpc, NavMeshAgent pAgent, Animator pAnimator, Transform pEnemy) : base(pNpc, pAgent, pAnimator, pEnemy)
    {
        currentState = Enums.States.Groggy;
    }

    public override void StateAwake()
    {
        base.StateAwake();
    }

    public override void StateStart()
    {
        base.StateStart();
    }

    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    public override void StateLateUpdate()
    {
        base.StateLateUpdate();
    }

    public override void StateExit()
    {
        base.StateExit();
    }
}

public class Dead : EnemyController
{
    public Dead(GameObject pNpc, NavMeshAgent pAgent, Animator pAnimator, Transform pEnemy) : base(pNpc, pAgent, pAnimator, pEnemy)
    {
        currentState = Enums.States.Dead;
    }

    public override void StateAwake()
    {
        base.StateAwake();
    }

    public override void StateStart()
    {
        base.StateStart();
    }

    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    public override void StateLateUpdate()
    {
        base.StateLateUpdate();
    }

    public override void StateExit()
    {
        base.StateExit();
    }
}