using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// principal manager에 등록된 manager들 업데이트 수행
/// </summary>
public class PrincipalUpdateManager : MonoBehaviour
{
    PrincipalManager principalManager = null;

    private void Update()
    {
        if(principalManager != null)
        {
            principalManager.UpdatePrincipalManager(Time.deltaTime);
        }
        else
        {
            principalManager = PrincipalManager.instance;
        }
    }
}
