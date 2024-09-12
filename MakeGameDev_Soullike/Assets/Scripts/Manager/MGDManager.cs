using UnityEngine;

public delegate void updateEventHandler();  // update callback

public class MGDManager : MonoBehaviour
{
    public event updateEventHandler updateEvent;    // update callback event

    public MGDManager() 
    { 
    }

    // ȣ��� �ʱ�ȭ
    public virtual void InitializeManager()
    { 
    }

    public virtual void Update()
    {
        updateEvent?.Invoke();
    }
}
