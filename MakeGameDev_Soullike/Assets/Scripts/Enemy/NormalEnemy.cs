using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NormalEnemy : BaseState
{
    protected Animator _animator;
    protected GameObject _npc;
    protected NavMeshAgent _agent;
    protected Transform _transform;

    protected float crossFadeTime = 0.1f;

    public NormalEnemy(GameObject pNpc, NavMeshAgent pAgent, Animator pAnimator, Transform pEnemy)
    {
        _npc = pNpc;
        _agent = pAgent;
        _animator = pAnimator;
        _transform = pEnemy;
        stateEvent = Enums.StateEvent.AWAKE;
    }

    public override void UpdateState(float fDeltaTime)
    {
        //Debug.Log("normalEnemy Update State...");
        Process();
    }
}

public class NormalEnemyIdle : NormalEnemy
{
    public NormalEnemyIdle(GameObject pNpc, NavMeshAgent pAgent, Animator pAnimator, Transform pEnemy) : base(pNpc, pAgent, pAnimator, pEnemy)
    {
        currentState = Enums.States.Idle;
    }

    public override void StateAwake()
    {
        base.StateAwake();
    }

    public override void StateStart()
    {
        _animator.SetCrossFade(currentState.ToString(), crossFadeTime, null);
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

public class NormalEnemyMove : NormalEnemy
{
    public NormalEnemyMove(GameObject pNpc, NavMeshAgent pAgent, Animator pAnimator, Transform pEnemy) : base(pNpc, pAgent, pAnimator, pEnemy)
    {
        currentState = Enums.States.Move;
    }

    public override void StateAwake()
    {
        base.StateAwake();
    }

    public override void StateStart()
    {
        _animator.SetCrossFade(currentState.ToString(), crossFadeTime, null);
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

public class NormalEnemyPatrol : NormalEnemy
{
    public NormalEnemyPatrol(GameObject pNpc, NavMeshAgent pAgent, Animator pAnimator, Transform pEnemy) : base(pNpc, pAgent, pAnimator, pEnemy)
    {
        currentState = Enums.States.Patrol;
    }

    public override void StateAwake()
    {
        base.StateAwake();
    }

    public override void StateStart()
    {
        _animator.SetCrossFade(currentState.ToString(), crossFadeTime, null);
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

public class NormalEnemyPursue : NormalEnemy
{
    public NormalEnemyPursue(GameObject pNpc, NavMeshAgent pAgent, Animator pAnimator, Transform pEnemy) : base(pNpc, pAgent, pAnimator, pEnemy)
    {
        currentState = Enums.States.Pursue;
    }

    public override void StateAwake()
    {
        base.StateAwake();
    }

    public override void StateStart()
    {
        _animator.SetCrossFade(currentState.ToString(), crossFadeTime, null);
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

public class NormalEnemyAttack : NormalEnemy
{
    public NormalEnemyAttack(GameObject pNpc, NavMeshAgent pAgent, Animator pAnimator, Transform pEnemy) : base(pNpc, pAgent, pAnimator, pEnemy)
    {
        currentState = Enums.States.Attack;
    }

    public override void StateAwake()
    {
        base.StateAwake();
    }

    public override void StateStart()
    {
        _animator.SetCrossFade(currentState.ToString(), crossFadeTime, null);
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

public class NormalEnemyDamaged : NormalEnemy
{
    public NormalEnemyDamaged(GameObject pNpc, NavMeshAgent pAgent, Animator pAnimator, Transform pEnemy) : base(pNpc, pAgent, pAnimator, pEnemy)
    {
        currentState = Enums.States.Damaged;
    }

    public override void StateAwake()
    {
        base.StateAwake();
    }

    public override void StateStart()
    {
        _animator.SetCrossFade(currentState.ToString(), crossFadeTime, null);
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

public class NormalEnemyGroggy : NormalEnemy
{
    public NormalEnemyGroggy(GameObject pNpc, NavMeshAgent pAgent, Animator pAnimator, Transform pEnemy) : base(pNpc, pAgent, pAnimator, pEnemy)
    {
        currentState = Enums.States.Groggy;
    }

    public override void StateAwake()
    {
        base.StateAwake();
    }

    public override void StateStart()
    {
        _animator.SetCrossFade(currentState.ToString(), crossFadeTime, null);
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

public class NormalEnemyDead : NormalEnemy
{
    public NormalEnemyDead(GameObject pNpc, NavMeshAgent pAgent, Animator pAnimator, Transform pEnemy) : base(pNpc, pAgent, pAnimator, pEnemy)
    {
        currentState = Enums.States.Dead;
    }

    public override void StateAwake()
    {
        base.StateAwake();
    }

    public override void StateStart()
    {
        _animator.SetCrossFade(currentState.ToString(), crossFadeTime, null);
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
