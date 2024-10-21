using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData")]
public class PlayerData : ScriptableObject
{
    public Data<float>  hp          = new Data<float>();
    public Data<float>  mp          = new Data<float>();
    public Data<float>  hitPoint    = new Data<float>();
    public Data<bool>   IsGuard     = new Data<bool>();
    public Data<bool>   IsAttack    = new Data<bool>();
}
