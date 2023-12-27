using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IState
{
    private Touch touch;
    public void EnterState(PlayerController player)
    {
        Debug.Log("Entering jump state");
    }

    public void UpdateState(PlayerController player)
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && player.canJump)
        {
            player.ChangeState(new JumpState());
            player.Jump();
        }
        else if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && player.canJump)
            {
                player.ChangeState(new JumpState());
                player.Jump();
            }
        }
        else
        {
            player.ChangeState(new RunState());
        }
    }

    public void ExitState(PlayerController player)
    {
        Debug.Log("Exiting jump state");
    }
}
