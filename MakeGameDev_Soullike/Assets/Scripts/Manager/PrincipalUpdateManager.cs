using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// principal manager�� ��ϵ� manager�� ������Ʈ ����
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
