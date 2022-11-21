using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementState
{
    public void InitController(PlayerController ctrl);
    public void HandleJump();
    public void HandleLand();
    public void HandleShoot();
    public void HandleStartScope();
    public void HandleStopScope();
    public void HandleMovement(Vector2 dir);
    public void HandleReload();
    public void HandleStartSprint();
    public void HandleStopSprint();
}
