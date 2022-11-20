using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateDefault : MovementState
{
    MovementController ctrl;

    public void InitController(MovementController ctrl)
    {
        this.ctrl = ctrl;
    }

    public void HandleJump()
    {
        //Jump
    }

    public void HandleLand()
    {
        //Nothing, should already be on land
    }

    public void HandleShoot()
    {
        //Fire current gun from hip
    }

    public void HandleStartScope()
    {
        //Transition to scope state
    }

    public void HandleStopScope()
    {
        //Nothing
    }

    public void HandleMovement()
    {
        //Handle WASD
    }

    public void HandleReload()
    {
        //Handles reload
    }

    public void HandleStartSprint()
    {
        //Transition to run state
    }

    public void HandleStopSprint()
    {
        //Nothing
    }
}
