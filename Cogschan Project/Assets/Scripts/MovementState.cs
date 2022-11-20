using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MovementState
{
    public void InitController(MovementController ctrl);
    public void HandleJump();
    public void HandleLand();
    public void HandleShoot();
    public void HandleStartScope();
    public void HandleStopScope();
    public void HandleMovement();
    public void HandleReload();
    public void HandleStartSprint();
    public void HandleStopSprint();
}
