using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/// <summary>
/// manager를 singleton으로 호출 할 수 있도록 관리하는 매니저
/// </summary>
public class PrincipalManager : MGDManager
{
    private GameObject principalUpdaterObj = null;
    private PrincipalUpdateManager principalUpdater = null;
    // isntance
    private static PrincipalManager Instance = null;

    // dic map
    protected Dictionary<string, MGDManager> mgdManagerMap  = new Dictionary<string, MGDManager>();
    protected Dictionary<string, BaseState>  baseStateMap   = new Dictionary<string, BaseState>();

    // class script name array
    protected string[] strManagerClassName = {
                                                "InputKeyManager",
                                             };

    // singleton initialize
    public static PrincipalManager instance
    {
        get
        {
            if(Instance == null)
            {
                Instance = new PrincipalManager();
                
                Instance.OnceInit();
            }

            return Instance;
        }
    }

    // 생성시 초기화
    public void OnceInit()
    {
        InitManagerUpdater();

        MGDManager pkManger = null;

        if (strManagerClassName.Length <= 0) return;    // 클래스 네임이 없으면 리턴

        foreach (string strClassName in strManagerClassName)
        {
            Assembly pkCreator = Assembly.GetExecutingAssembly();

            object pkObject = pkCreator.CreateInstance(strClassName);

            if(pkObject != null)
            {
                if (pkObject.GetType().IsSubclassOf(typeof(MGDManager)))
                {
                    pkManger = (MGDManager)pkObject;
                    mgdManagerMap.Add(strClassName, pkManger);
                }
            }
            else
            {
                Debug.LogError("CreateInstance error");
            }
        }

        foreach (MGDManager pkIterManager in mgdManagerMap.Values) 
        {
            pkIterManager.InitializeManager();
        }
    }

    public void InitManagerUpdater()
    {
        if(principalUpdater == null)
        {
            principalUpdaterObj = new GameObject("PrincipalUpdater");
            principalUpdater = principalUpdaterObj.AddComponent<PrincipalUpdateManager>();
            GameObject.DontDestroyOnLoad(principalUpdaterObj);
        }
    }

    public override void InitializeManager()
    {
        base.InitializeManager();
    }

    public void UpdatePrincipalManager(float fDeltaTime)
    {
        if (mgdManagerMap.Count > 0)
        {
            foreach(MGDManager pkManager in mgdManagerMap.Values)
            {
                if(pkManager != null)
                {
                    pkManager.UpdateManger(fDeltaTime);
                }
            }
        }

        if (baseStateMap.Count > 0)
        {
            foreach (BaseState pkManager in baseStateMap.Values)
            {
                if (pkManager != null)
                {
                    pkManager.UpdateState(fDeltaTime);
                }
            }
        }
    }

    public T GetManager<T>() where T : MGDManager
    {
        if (mgdManagerMap.ContainsKey(typeof(T).ToString()))
        {
            return(T)mgdManagerMap[typeof(T).ToString()];
        }

        return null;
    }

    public void AddState<T>(string strKey, BaseState pBaseState)
    {
        if (baseStateMap.ContainsKey(strKey) == false)
        {
            baseStateMap.Add(strKey, pBaseState);
        }
        else
        {
            baseStateMap[strKey] = pBaseState;
        }
    }

    public void RemoveState<T>(string strKey)
    {
        if (baseStateMap.ContainsKey(strKey) == true)
        {
            baseStateMap.Remove(strKey);
        }
    }
}
