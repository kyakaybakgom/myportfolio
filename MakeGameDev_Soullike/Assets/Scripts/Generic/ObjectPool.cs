using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    private Dictionary<string, Queue<GameObject>> objectPoolDic = new Dictionary<string, Queue<GameObject>>();

    // �ű� ������Ʈ ����
    public GameObject CreateNewObject(GameObject _obj)
    {
        var newObj = Instantiate(_obj);
        newObj.SetActive(false);
        newObj.transform.SetParent(transform);

        return newObj;
    }
    
    // pool �ʱ�ȭ
    public void InitializeDic(string strKey, GameObject _obj, int addValue)
    {
        if (objectPoolDic.ContainsKey(strKey) == false)
        {
            objectPoolDic.Add(strKey, new Queue<GameObject>());
        }

        for (int i = 0; i < addValue; i++)
        {
            objectPoolDic[strKey].Enqueue(CreateNewObject(_obj));
        }
    }

    // pool ������
    public static GameObject GetObject(string strKey, GameObject pObj)
    {
        GameObject _obj = null;

        Instance.objectPoolDic.TryGetValue(strKey, out var getQue);

        if (getQue != null)
        {
            if(getQue.Count > 0)
            {
                _obj = getQue.Dequeue();
            }
            else
            {
                _obj = Instance.CreateNewObject(pObj);
            }

            _obj.transform.SetParent(null);
            _obj.SetActive(true);
        }

        return _obj;
    }

    // pool �ֱ�
    public static void ReturnObject(string strKey, GameObject pObj)
    {
        pObj.SetActive(false);
        pObj.transform.SetParent(Instance.transform);

        Instance.objectPoolDic.TryGetValue(strKey, out var getQue);

        if (getQue == null)
        {
            Instance.objectPoolDic.Add(strKey, new Queue<GameObject>());
            Instance.objectPoolDic[strKey].Enqueue(pObj);
        }
        else
        {
            getQue.Enqueue(pObj);
        }
    }
}
