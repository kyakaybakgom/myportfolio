using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 몬스터 공용 interface
/// </summary>
public interface IMonsterControll
{
    public void Attack();
    public void Move(Vector3 pTargetPos);
    public void FindPlayer();
    public void Damaged(float pDamage);
    public void Dead();
    public void Animate(string pAnimName);
}
