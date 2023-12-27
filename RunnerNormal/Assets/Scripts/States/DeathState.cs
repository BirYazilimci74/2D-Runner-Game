using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : IState
{
    public void EnterState(PlayerController player)
    {
        Debug.Log("Entering death state");
    }

    public void UpdateState(PlayerController player)
    {
        if (!GameManager.Instance.canPlay)
        {
            player.ChangeState(new DeathState());
            //player.Death();
        }
        else
        {
            player.ChangeState(new JumpState());
        }
    }

    public void ExitState(PlayerController player)
    {
        Debug.Log("Exiting death state");
    }
}
