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

    private const string controllerName = "SlimeController";

    private void Start()
    {
        animator = GetComponent<Animator>();

        currentState = new NormalEnemyIdle(this.gameObject, agent, animator, player);
        PrincipalManager.instance.AddState<SlimeController>(controllerName, currentState);

        StartCoroutine(testFunc());
    }

    IEnumerator testFunc()
    {
        yield return new WaitForSeconds(3);

        currentState.StateExit();
        currentState = new NormalEnemyMove(this.gameObject, agent, animator, player);
        PrincipalManager.instance.AddState<SlimeController>(controllerName, currentState);

        yield return new WaitForSeconds(3);

        currentState.StateExit();
        currentState = new NormalEnemyPursue(this.gameObject, agent, animator, player);
        PrincipalManager.instance.AddState<SlimeController>(controllerName, currentState);

        yield return new WaitForSeconds(3);

        currentState.StateExit();
        currentState = new NormalEnemyAttack(this.gameObject, agent, animator, player);
        PrincipalManager.instance.AddState<SlimeController>(controllerName, currentState);

        yield return new WaitForSeconds(3);

        currentState.StateExit();
        currentState = new NormalEnemyDamaged(this.gameObject, agent, animator, player);
        PrincipalManager.instance.AddState<SlimeController>(controllerName, currentState);

        yield return new WaitForSeconds(3);

        currentState.StateExit();
        currentState = new NormalEnemyGroggy(this.gameObject, agent, animator, player);
        PrincipalManager.instance.AddState<SlimeController>(controllerName, currentState);

        yield return new WaitForSeconds(3);

        currentState.StateExit();
        currentState = new NormalEnemyDead(this.gameObject, agent, animator, player);
        PrincipalManager.instance.AddState<SlimeController>(controllerName, currentState);
    }
}
