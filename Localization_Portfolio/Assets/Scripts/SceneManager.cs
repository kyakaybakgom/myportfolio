using System.Collections;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        while(DataManager.Instance.IsReady == false)
        {
            yield return null;
        }

        string str = DataManager.Instance.GetLocalizedText(Const.PATH_LOCALIZATION_SYSTEM, "Start_System");
        Debug.Log("Load Localization Text : " + str);
    }
}
