using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void StateAwake();
    public void StateStart();
    public void StateFixedUpdate();
    public void StateUpdate();
    public void StateLateUpdate();
    public void StateExit();
}
