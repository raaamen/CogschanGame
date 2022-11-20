using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateADSJump : MovementState
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
        //Go to landed ADS state
    }

    public void HandleShoot()
    {
        //Fire current gun with high accuracy
    }

    public void HandleStartScope()
    {
        //Do nothing
    }

    public void HandleStopScope()
    {
        //Go to regular jump state
    }

    public void HandleMovement()
    {
        //Move but slowly
    }

    public void HandleReload()
    {
        //Reload
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
