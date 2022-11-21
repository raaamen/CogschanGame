using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private MovementState state;
    private Rigidbody rb;
    private Collider hitbox;
    private InputMappings inputMappings;

    public Gun Gun;

    void Awake()
    {
        state = new MovementStateDefault();
        state.InitController(this);

        inputMappings = new InputMappings();
        inputMappings.Enable();

        inputMappings.Movement.Jump.performed += _ => state.HandleJump();
        inputMappings.Movement.Run.performed += _ => state.HandleStartSprint();
        inputMappings.Movement.Run.canceled += _ => state.HandleStopSprint();
        inputMappings.Weapon.Reload.performed += _ => state.HandleReload();
        inputMappings.Weapon.Shoot.started += _ => state.HandleShoot();
        inputMappings.Weapon.ADS.performed += _ => state.HandleStartScope();
        inputMappings.Weapon.ADS.canceled += _ => state.HandleStopScope();
    }

    private void OnEnable()
    {
        inputMappings.Enable();
    }

    private void OnDisable()
    {
        inputMappings.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 dir = inputMappings.Movement.Move.ReadValue<Vector2>();
        state.HandleMovement(dir);
    }

    public void SetState(MovementState state)
    {
        this.state = state;
    }
}
