using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IPlayerControll
{
    [SerializeField] private PlayerInput        playerInput;    // �÷��̾� Ű �Է�
    [SerializeField] private Animator           playerAnimator; // �÷��̾� animator
    
    public PlayerData           playerData;         // �÷��̾� ������

    private InputKeyManager     inputKeyManager;    // Ű �Է� ���� ��ũ��Ʈ

    // action callback
    private InputAction moveAction      = null;     // ������
    private InputAction fireAction      = null;     // �����
    private InputAction fireAction2     = null;     // ������
    private InputAction dependAction    = null;     // ���
    private InputAction parryAction     = null;     // �и�

    // player transform
    private Transform playerTr;

    // weapon collider
    [SerializeField] private BoxCollider swordCol;

    public void Start()
    {
        playerTr = this.transform;

        PlayerDataInit();

        playerInput.onActionTriggered += ActionTrigger;

        // action �Ҵ�
        moveAction      = playerInput.currentActionMap.FindAction(Constants.CharcterMove);
        fireAction      = playerInput.currentActionMap.FindAction(Constants.CharcterFire);
        fireAction2     = playerInput.currentActionMap.FindAction(Constants.CharcterFire2);
        dependAction    = playerInput.currentActionMap.FindAction(Constants.CharacterGuard);
        parryAction     = playerInput.currentActionMap.FindAction(Constants.CharacterParry);
        
        // inputkeymanager key add
        inputKeyManager = PrincipalManager.instance.GetManager<InputKeyManager>();
        inputKeyManager.AddKey(Constants.CharcterMove, () => Move(moveAction.ReadValue<Vector2>()));
    }

    void PlayerDataInit()
    {
        playerData.hp.Value = 100;
        playerData.mp.Value = 100;
        playerData.hitPoint.Value = 100;
        playerData.IsGuard.Value = false;
    }

    // action trigger callback
    void ActionTrigger(InputAction.CallbackContext context)
    {
        if (context.performed == false)
        {
            if (context.action == dependAction)
            {
                playerData.IsGuard.Value = false;
                playerAnimator.SetBool(Constants.AnimGuard, false);
            }

            return;
        }

        if(context.action == fireAction)    //�����
        {
            playerData.IsAttack.Value = true;
            swordCol.enabled = true;
            Animate(Constants.AnimAttackA, () =>
            {
                playerData.IsAttack.Value = false;
                swordCol.enabled = false;
            });
        }
        else if(context.action == fireAction2)  // ������
        {
            playerData.IsAttack.Value = true;
            swordCol.enabled = true;
            Animate(Constants.AnimAttackB, () =>
            {
                playerData.IsAttack.Value = false;
                swordCol.enabled = false;
            });
        }
        else if (context.action == dependAction)    // ����
        {
            playerData.IsGuard.Value = true;
            playerAnimator.SetBool(Constants.AnimGuard, true);
        }
        else if (context.action == parryAction) // �и�
        {
            Animate(Constants.AnimParry);
        }
    }

    // controller input axis
    public void Move(Vector2 pVector2)
    {
        //Debug.Log($"move axis : {pVector2.x}, {pVector2.y}");

        playerAnimator.SetFloat("Xaxis", pVector2.x);
        playerAnimator.SetFloat("Yaxis", pVector2.y);
        playerTr.position = new Vector3(playerTr.position.x + (pVector2.x * Time.fixedDeltaTime), playerTr.position.y, playerTr.position.z + (pVector2.y * Time.fixedDeltaTime));
    }

    // animation crossfade
    public void Animate(string pAnimName, Action onFinished = null)
    {
        playerAnimator.SetCrossFade(pAnimName, Constants.AnimationCrossFadeTime, onFinished);
    }

    public void Attack(float pButton)
    {
        //Debug.Log($"attack axis : {pButton}");
    }

    // recieve damage to monster
    public void Damaged(float pDamage)
    {
        if (playerData.IsGuard.Value)
        {

        }
        else
        {
            playerData.hp.Value -= pDamage;
        }
    }

    // player dead
    public void Dead()
    {
        if (playerData.hp.Value <= 0)
        {
            Animate(Constants.AnimDead);
        }
    }

    #region Collision

    private void OnCollisionEnter(Collision collision)
    {
        // ������ ó��
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }

    #endregion

    private void OnDisable()
    {
        inputKeyManager.ClearStrKey();
    }
}
