using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    private Transform player;
    private NormalEnemy currentState;

    private void Start()
    {
        PrincipalManager.instance.AddState<SlimeController>("SlimeController", currentState);

        currentState = new NormalEnemyIdle(this.gameObject, agent, animator, player);
    }

}
