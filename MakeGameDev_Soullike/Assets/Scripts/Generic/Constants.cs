using System.Collections;
using System.Collections.Generic;

public static class Constants
{
    // player
    public const string CharcterMove    = "Move";
    public const string CharcterFire    = "Fire";
    public const string CharcterFire2   = "Fire2";
    public const string CharacterGuard  = "Guard";
    public const string CharacterParry  = "Parry";
    public const string CharacterCam    = "CameraController";

    public const float CharacterMoveSpeed = 2f;

    // enemy
    public const string EnemyTag = "Enemy";

    // 공용
    public const string AnimAttackA = "AttackA";
    public const string AnimAttackB = "AttackB";
    public const string AnimDead    = "Dead";
    public const string AnimGuard   = "IsGuard";
    public const string AnimParry   = "ParryAnim";

    public const float AnimationCrossFadeTime = 0.1f;

    // 애니메이션
    public const string AnimationStartEventFunctionName = "AnimationStartHandler";
    public const string AnimationEndEventFunctionName   = "AnimationEndHandler";
}
