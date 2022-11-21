using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateDefault : IMovementState
{
    PlayerController ctrl;

    public void InitController(PlayerController ctrl)
    {
        this.ctrl = ctrl;
    }

    public void HandleJump()
    {
        Debug.Log("Jumping");
    }

    public void HandleLand()
    {
        //Nothing
    }

    public void HandleShoot()
    {
        Debug.Log("Firing from hip");
    }

    public void HandleStartScope()
    {
        /*MovementState s = (MovementState)new MovementStateADS();
        s.InitController(ctrl);
        ctrl.SetState(s);*/
    }

    public void HandleStopScope()
    {
        //Nothing
    }

    public void HandleMovement(Vector2 dir)
    {
        Debug.Log("Jogging in the direction " + dir);
    }

    public void HandleReload()
    {
        Debug.Log("Reloading");
    }

    public void HandleStartSprint()
    {
        /*MovementState s = (MovementState)new MovementStateRunning();
        s.InitController(ctrl);
        ctrl.SetState(s);*/
    }

    public void HandleStopSprint()
    {
        //Nothing
    }
}
