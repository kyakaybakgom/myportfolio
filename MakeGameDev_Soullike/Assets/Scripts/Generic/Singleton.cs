using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ÂüÁ¶ : https://postpiglet.netlify.app/posts/csharp-singletone-vs-staticclass/
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance = null;
    private static object _syncObj = new object();
    private static bool appIsClosing = false;

    public static T Instance
    {
        get
        {
            if (appIsClosing == true)
                return null;

            lock (_syncObj)
            {
                if (instance == null)
                {
                    T[] objs = FindObjectsOfType<T>();

                    if (objs.Length > 0)
                        instance = objs[0];

                    if (objs.Length > 1)
                        Debug.LogError("There is more than one " + typeof(T).Name + " in the Scene");

                    if (instance == null)
                    {
                        string name = typeof(T).ToString();
                        GameObject go = GameObject.Find(name);
                        if (go == null)
                            go = new GameObject(name);
                        instance = go.AddComponent<T>();
                    }
                }
                return instance;
            }
        }
    }
}
