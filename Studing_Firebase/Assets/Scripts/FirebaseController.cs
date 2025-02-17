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
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>    // 버전 체크
        {
            if (task.Result == Firebase.DependencyStatus.Available)  // 결과가 괜찮으면, 문제가 없다면
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
        m_auth.StateChanged += AuthStateChanged;    // 상태가 변하면 해당 함수를 호출
    }

    private void AuthStateChanged(object sender, EventArgs e)
    {
        FirebaseAuth senderAuth = sender as FirebaseAuth;   // 상태 변화가 생기면 sender와 e가 작용

        if(senderAuth != null)  // 유저가 있다면
        {
            m_user = senderAuth.CurrentUser;

            if(m_user != null)  // 유저가 null이 아니면
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
