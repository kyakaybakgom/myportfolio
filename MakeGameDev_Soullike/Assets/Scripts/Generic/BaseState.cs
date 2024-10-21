using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseState : IState
{
    public Enums.States currentState    { get; set; }
    protected Enums.StateEvent      stateEvent      { get; set; }
    protected Enums.States nextState       {  get; set; }

    public BaseState() 
    {
        stateEvent = Enums.StateEvent.AWAKE;
    }

    public virtual void UpdateState(float fDeltaTime)
    {

    }

    public virtual void StateAwake()
    {
        stateEvent = Enums.StateEvent.START;
    }
    public virtual void StateStart()
    {
        stateEvent = Enums.StateEvent.FIXEDUPDATE;
    }

    public virtual void StateFixedUpdate()
    {
        stateEvent = Enums.StateEvent.UPDATE;
    }
    public virtual void StateUpdate()
    {
        stateEvent = Enums.StateEvent.LATEUPDATE;
    }

    public virtual void StateLateUpdate()
    {
        stateEvent = Enums.StateEvent.FIXEDUPDATE;
    }

    public virtual void StateExit()
    {
        stateEvent = Enums.StateEvent.EXIT;
    }

    public Enums.States Process()
    {
        if(stateEvent == Enums.StateEvent.AWAKE) StateAwake();
        if(stateEvent == Enums.StateEvent.START) StateStart();
        if(stateEvent == Enums.StateEvent.FIXEDUPDATE) StateFixedUpdate();
        if(stateEvent == Enums.StateEvent.UPDATE) StateUpdate();
        if(stateEvent == Enums.StateEvent.LATEUPDATE) StateLateUpdate();
        if(stateEvent == Enums.StateEvent.EXIT)
        {
            StateExit();
            return nextState;
        }

        return currentState;
    }
}
