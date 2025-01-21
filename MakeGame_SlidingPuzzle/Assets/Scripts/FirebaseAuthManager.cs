using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase.Auth;
using TMPro;

using UnityEngine.UI;

using Button = UnityEngine.UI.Button;

public class FirebaseAuthManager : MonoBehaviour
{
    private FirebaseAuth    auth;               // ������ ���� ���� ����
    public TMP_InputField   inputEmail;
    public TMP_InputField   inputPassword;
    public TMP_Text         txtAction;          // �α����� �ߴ��� �α׾ƿ��� �ߴ��� �˷��ִ� â

    public Button loginBt;
    public Button logoutBt;
    public Button CreateBt;

    // Start is called before the first frame update
    void Start()
    {
        InitFunc();

        auth = FirebaseAuth.DefaultInstance;
    }

    // �ʱ�ȭ
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

    // ���� ����
    public void CreateFunc()
    {
        auth.CreateUserWithEmailAndPasswordAsync(inputEmail.text, inputPassword.text).ContinueWith(task =>
        {
            if (task.IsFaulted) // ���� ������ ������ ���
            {
                Debug.Log("���� ���� ����");
                return;
            }

            if (task.IsCanceled) // ���� ������ �������� ��� (��Ʈ��ũ ���, ���� ���)
            {
                Debug.Log("���� ���� ���");
                return;
            }

            FirebaseUser newUser = task.Result.User;    // ���� ������ �������� ���
        });
    }

    // �α���
    public void LogInFunc()
    {
        auth.SignInWithEmailAndPasswordAsync(inputEmail.text, inputPassword.text).ContinueWith(task =>
        {
            if (task.IsFaulted) // �α����� ������ ���
            {
                Debug.Log("login failed");
                return;
            }

            if (task.IsCanceled) // �α����� �������� ��� (��Ʈ��ũ ���, �α��� ���)
            {
                Debug.Log("login canceled");
                return;
            }

            Debug.Log("login success");
        });
    }

    // �α׾ƿ�
    public void LogoutFunc()
    {
        auth.SignOut();
        Debug.Log("logout");    // �α׾ƿ� �α� �޽���
    }
}
