using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// key �Է� ���� �Ŵ���
/// </summary>
public class InputKeyManager : MGDManager
{ 
    private Dictionary<KeyCode, Action> keyCodes;
    private Dictionary<string, Action>  strKeyActions;

    // �ʱ�ȭ
    public override void InitializeManager()
    {
        keyCodes = new Dictionary<KeyCode, Action>();
        strKeyActions = new Dictionary<string, Action>();

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

    // strKey �߰�
    public void AddKey(string keyStr, Action action)
    {
        if (strKeyActions.ContainsKey(keyStr) == false)
        {
            strKeyActions.Add(keyStr, action);
        }
    }

    // strKey ����
    public void RemoveKey(string keyStr)
    {
        if (strKeyActions.ContainsKey(keyStr))
        {
            strKeyActions.Remove(keyStr);
        }
    }

    // strKey clear
    public void ClearStrKey()
    {
        strKeyActions.Clear();
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

        if (strKeyActions.Count > 0)
        {
            foreach (var key in strKeyActions)
            {
                key.Value.Invoke();
            }
        }
    }
}
