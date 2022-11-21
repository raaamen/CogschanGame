using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateRunning : MovementState
{
    PlayerController ctrl;

    public void InitController(PlayerController ctrl)
    {
        this.ctrl = ctrl;
    }

    public void HandleJump()
    {
        Debug.Log("Run-jumping");
    }

    public void HandleLand()
    {
        //Nothing
    }

    public void HandleShoot()
    {
        //Nothing
    }

    public void HandleStartScope()
    {
        //Nothing
    }

    public void HandleStopScope()
    {
        //Nothing
    }

    public void HandleMovement(Vector2 dir)
    {
        Debug.Log("Running in the direction " + dir);
    }

    public void HandleReload()
    {
        //Nothing
    }

    public void HandleStartSprint()
    {
        //Nothing
    }

    public void HandleStopSprint()
    {
        MovementState s = (MovementState)new MovementStateDefault();
        s.InitController(ctrl);
        ctrl.SetState(s);
    }
}
