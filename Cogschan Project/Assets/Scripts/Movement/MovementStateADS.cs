using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateADS : MovementState
{
    PlayerController ctrl;

    public void InitController(PlayerController ctrl)
    {
        this.ctrl = ctrl;
    }

    public void HandleJump()
    {
        //Nothing
    }

    public void HandleLand()
    {
        //Nothing
    }

    public void HandleShoot()
    {
        Debug.Log("Firing accurately");
    }

    public void HandleStartScope()
    {
        //Nothing, already here
    }

    public void HandleStopScope()
    {
        MovementState s = (MovementState)new MovementStateDefault();
        s.InitController(ctrl);
        ctrl.SetState(s);
    }

    public void HandleMovement(Vector2 dir)
    {
        Debug.Log("Slowly creeping in the direction " + dir);
    }

    public void HandleReload()
    {
        Debug.Log("Reloading");
    }

    public void HandleStartSprint()
    {
        //Nothing
    }

    public void HandleStopSprint()
    {
        //Nothing
    }
}
