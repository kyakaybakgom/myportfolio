using Firebase.Auth;
using Firebase.Extensions;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;

using TMPro;
using Button = UnityEngine.UI.Button;

public class FirebaseController : MonoBehaviour
{
    private FirebaseAuth m_auth;
    private FirebaseUser m_user;

    [SerializeField] Button guestBt;

    // Start is called before the first frame update
    void Start()
    {
        ButtonInit();
        FirebaseControllerInit();
    }

    private void ButtonInit()
    {
        guestBt.onClick.AddListener(SignIn);
    }

    private void FirebaseControllerInit()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>    // ���� üũ
        {
            if (task.Result == Firebase.DependencyStatus.Available)  // ����� ��������, ������ ���ٸ�
            {
                FirebaseInit();
            }
            else
            {
                Debug.LogError("FirebaseApp ver check error...");
            }
        });
    }

    private void FirebaseInit()
    {
        m_auth = FirebaseAuth.DefaultInstance;
        m_auth.StateChanged += AuthStateChanged;    // ���°� ���ϸ� �ش� �Լ��� ȣ��
    }

    private void AuthStateChanged(object sender, EventArgs e)
    {
        FirebaseAuth senderAuth = sender as FirebaseAuth;   // ���� ��ȭ�� ����� sender�� e�� �ۿ�

        if(senderAuth != null)  // ������ �ִٸ�
        {
            m_user = senderAuth.CurrentUser;

            if(m_user != null)  // ������ null�� �ƴϸ�
            {
                Debug.Log("AuthStateChanged user id : " + m_user.UserId);
            }
        }
    }

    #region guest account

    public void SignIn()
    {
        SignInAnonymous();
    }

    private Task SignInAnonymous()
    {
        return m_auth.SignInAnonymouslyAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("signIn Failed");
            }
            else if(task.IsCompleted)
            {
                Debug.Log("signIn Completed");
            }
        });
    }

    #endregion
}
