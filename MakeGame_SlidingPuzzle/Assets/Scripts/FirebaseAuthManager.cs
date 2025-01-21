using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase.Auth;
using TMPro;

using UnityEngine.UI;

using Button = UnityEngine.UI.Button;

public class FirebaseAuthManager : MonoBehaviour
{
    private FirebaseAuth    auth;               // 인증을 위한 변수 선언
    public TMP_InputField   inputEmail;
    public TMP_InputField   inputPassword;
    public TMP_Text         txtAction;          // 로그인을 했는지 로그아웃을 했는지 알려주는 창

    public Button loginBt;
    public Button logoutBt;
    public Button CreateBt;

    // Start is called before the first frame update
    void Start()
    {
        InitFunc();

        auth = FirebaseAuth.DefaultInstance;
    }

    // 초기화
    void InitFunc()
    {
        loginBt?.onClick.AddListener(LogInFunc);
        logoutBt?.onClick.AddListener(LogoutFunc);
        CreateBt?.onClick.AddListener(CreateFunc);
    }

    private void OnDisable()
    {
        loginBt?.onClick.RemoveAllListeners();
        logoutBt?.onClick.RemoveAllListeners();
        CreateBt?.onClick.RemoveAllListeners();
    }

    // 계정 생성
    public void CreateFunc()
    {
        auth.CreateUserWithEmailAndPasswordAsync(inputEmail.text, inputPassword.text).ContinueWith(task =>
        {
            if (task.IsFaulted) // 계정 생성을 못했을 경우
            {
                Debug.Log("계정 생성 실패");
                return;
            }

            if (task.IsCanceled) // 계정 생성을 실패했을 경우 (네트워크 장애, 도중 취소)
            {
                Debug.Log("계정 생성 취소");
                return;
            }

            FirebaseUser newUser = task.Result.User;    // 계정 생성에 성공했을 경우
        });
    }

    // 로그인
    public void LogInFunc()
    {
        auth.SignInWithEmailAndPasswordAsync(inputEmail.text, inputPassword.text).ContinueWith(task =>
        {
            if (task.IsFaulted) // 로그인을 못했을 경우
            {
                Debug.Log("login failed");
                return;
            }

            if (task.IsCanceled) // 로그인을 실패했을 경우 (네트워크 장애, 로그인 취소)
            {
                Debug.Log("login canceled");
                return;
            }

            Debug.Log("login success");
        });
    }

    // 로그아웃
    public void LogoutFunc()
    {
        auth.SignOut();
        Debug.Log("logout");    // 로그아웃 로그 메시지
    }
}
