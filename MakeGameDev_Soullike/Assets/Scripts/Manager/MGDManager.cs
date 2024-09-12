using UnityEngine;

public delegate void updateEventHandler();  // update callback

public class MGDManager : MonoBehaviour
{
    public event updateEventHandler updateEvent;    // update callback event

    public MGDManager() 
    { 
    }

    // 호출시 초기화
    public virtual void InitializeManager()
    { 
    }

    public virtual void Update()
    {
        updateEvent?.Invoke();
    }
}
