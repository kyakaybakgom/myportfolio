using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/EnemyData")]
public class EnemyData : ScriptableObject
{
    public Data<float>  enemyHp         = new Data<float>();
    public Data<float>  enemyMp         = new Data<float>();
    public Data<float>  enemyHitPoint   = new Data<float>();
    public Data<bool>   enemyIsGuard    = new Data<bool>();
    public Data<bool>   enemyIsAttack   = new Data<bool>();
    public Data<string> enemyName       = new Data<string>();
}
