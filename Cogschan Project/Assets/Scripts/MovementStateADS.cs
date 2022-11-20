using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateADS : MovementState
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
        //Nothing
    }

    public void HandleShoot()
    {
        //Fire current gun with high accuracy
    }

    public void HandleStartScope()
    {
        //Nothing, already here
    }

    public void HandleStopScope()
    {
        //Go to default state
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
