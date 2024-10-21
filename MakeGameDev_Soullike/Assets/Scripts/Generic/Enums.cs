using System.Collections;
using System.Collections.Generic;

public static class Enums
{
    public enum States
    {
        None = 0,
        Idle,       // ������ �ִ� ����
        Move,       // �̵� ����
        Patrol,     // ���� ����
        Pursue,     // �߰� ����
        Attack,     // ���� ����
        Damaged,    // ���� ���� ����
        Groggy,     // ȥ�� ����
        Dead,       // ���� ����
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
