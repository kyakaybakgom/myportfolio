using System.Collections;
using System.Collections.Generic;

public static class Enums
{
    public enum States
    {
        None = 0,
        Idle,       // 가만히 있는 상태
        Move,       // 이동 상태
        Patrol,     // 순찰 상태
        Pursue,     // 추격 상태
        Attack,     // 공격 상태
        Damaged,    // 피해 입은 상태
        Groggy,     // 혼란 상태
        Dead,       // 죽음 상태
    }

    public enum StateEvent
    {
        AWAKE,
        START,
        FIXEDUPDATE,
        UPDATE,
        LATEUPDATE,
        EXIT,
    }
}
