using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// key 입력 관리 매니저
/// </summary>
public class InputKeyManager : MGDManager
{ 
    private Dictionary<KeyCode, Action> keyCodes;
    private Dictionary<string, Action>  strKeyActions;

    // 초기화
    public override void InitializeManager()
    {
        keyCodes = new Dictionary<KeyCode, Action>();
        strKeyActions = new Dictionary<string, Action>();

        Debug.Log("InputKeyManager Init...");

        this.AddKey(KeyCode.Space, () => Debug.Log("key down space"));
    }

    // key 추가
    public void AddKey(KeyCode keyCode, Action action)
    {
        if (keyCodes.ContainsKey(keyCode) == false)
        {
            keyCodes.Add(keyCode, action);
        }
    }

    // key 삭제
    public void RemoveKey(KeyCode keyCode) 
    {
        if(keyCodes.ContainsKey(keyCode))
        {
            keyCodes.Remove(keyCode);
        }
    }

    // strKey 추가
    public void AddKey(string keyStr, Action action)
    {
        if (strKeyActions.ContainsKey(keyStr) == false)
        {
            strKeyActions.Add(keyStr, action);
        }
    }

    // strKey 삭제
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

    // key 입력 받아 처리
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
