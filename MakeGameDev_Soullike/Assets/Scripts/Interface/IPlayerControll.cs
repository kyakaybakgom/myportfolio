using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어 interface
/// </summary>
public interface IPlayerControll
{
    public void Move(Vector2 pVector2);
    public void Attack(float pButton);
    public void Damaged(float pDamage);
    public void Animate(string pAnimName, Action onFinished);
    public void Dead();
}
