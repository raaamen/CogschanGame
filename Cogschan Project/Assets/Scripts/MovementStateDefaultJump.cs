using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateDefaultJump : MonoBehaviour
{
    MovementController ctrl;

    public void InitController(MovementController ctrl)
    {
        this.ctrl = ctrl;
    }

    public void HandleJump()
    {
        //Nothing (double jump???)
    }

    public void HandleLand()
    {
        //Go to default state
    }

    public void HandleShoot()
    {
        //Fire current gun from hip
    }

    public void HandleStartScope()
    {
        //Transition to scoped jump state
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
        //Nothing
    }

    public void HandleStopSprint()
    {
        //Nothing
    }
}
