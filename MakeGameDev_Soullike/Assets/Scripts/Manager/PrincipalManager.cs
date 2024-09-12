using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PrincipalManager : MGDManager
{
    // isntance
    private static PrincipalManager Instance = null;

    // dic map
    protected Dictionary<string, MGDManager> mgdManagerMap = new Dictionary<string, MGDManager>();

    // class script name array
    protected string[] strManagerClassName = { };

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
        InitManager();

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

    public void InitManager()
    {

    }

    public override void InitializeManager()
    {
        base.InitializeManager();
    }
}
