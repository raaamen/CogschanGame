using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateRunJump : MovementState
{
    MovementController ctrl;

    public void InitController(MovementController ctrl)
    {
        this.ctrl = ctrl;
    }

    public void HandleJump()
    {
        //Nothing
    }

    public void HandleLand()
    {
        //Go to landed run state
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

    public void HandleMovement()
    {
        //Move but fast
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
        //Nothing
    }
}
