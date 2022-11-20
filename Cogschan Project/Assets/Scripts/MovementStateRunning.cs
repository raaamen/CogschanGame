using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateRunning : MovementState
{
    MovementController ctrl;

    public void InitController(MovementController ctrl)
    {
        this.ctrl = ctrl;
    }

    public void HandleJump()
    {
        //Run jump
    }

    public void HandleLand()
    {
        //Nothing
    }

    public void HandleShoot()
    {
        //Fire current gun with high accuracy
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
        //Go to default state
    }
}
