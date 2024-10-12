using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// key �Է� ���� �Ŵ���
/// </summary>
public class InputKeyManager : MGDManager
{ 
    private Dictionary<KeyCode, Action> keyCodes;

    // �ʱ�ȭ
    public override void InitializeManager()
    {
        keyCodes = new Dictionary<KeyCode, Action>();

        Debug.Log("InputKeyManager Init...");

        this.AddKey(KeyCode.Space, () => Debug.Log("key down space"));
    }

    // key �߰�
    public void AddKey(KeyCode keyCode, Action action)
    {
        if (keyCodes.ContainsKey(keyCode) == false)
        {
            keyCodes.Add(keyCode, action);
        }
    }

    // key ����
    public void RemoveKey(KeyCode keyCode) 
    {
        if(keyCodes.ContainsKey(keyCode))
        {
            keyCodes.Remove(keyCode);
        }
    }

    // key �Է� �޾� ó��
    public override void UpdateManger(float fDeltaTime)
    {
        if (Input.anyKeyDown)
        {
            foreach (var key in keyCodes)
            {
                if (Input.GetKeyDown(key.Key))
                {
                    key.Value.Invoke();
                }
            }
        }
    }
}
