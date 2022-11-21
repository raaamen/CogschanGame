using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// States for movement.
/// </summary>
public enum MovementState
{
    Jog,
    Run,
    ADS,
}

/// <summary>
/// States for non-movement related actions.
/// </summary>
public enum ActionState
{
    None,
    Fire,
    Reload,
    Dash,
}

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Don't modify directly. Use <see cref="MoveState"/> instead.
    /// </summary>
    private MovementState _movementState;
    /// <summary>
    /// Don't modify directly. Use <see cref="ActState"/> instead.
    /// </summary>
    private ActionState _actionState;
    private Rigidbody rb;
    private Collider hitbox;
    private InputMappings inputMappings;

    public Gun Gun;

    private MovementState MoveState
    {
        get { return _movementState; }
        set 
        { 
            switch (value)
            {
                case MovementState.Jog:
                    break;
                case MovementState.Run:
                    if (_movementState == MovementState.ADS || _actionState == ActionState.Fire)
                        return;
                    break;
                case MovementState.ADS:
                    if (_movementState == MovementState.Run)
                        return;
                    break;
            }
            _movementState = value;
        }
    }
    private ActionState ActState
    {
        get { return _actionState; }
        set
        {
            switch (value)
            {
                case ActionState.None:
                    break;
                case ActionState.Fire:
                    if (_actionState == ActionState.Reload || _movementState == MovementState.Run)
                        return;
                    break;
                case ActionState.Reload:
                    break;
                case ActionState.Dash:
                    if (_movementState == MovementState.ADS)
                        return;
                    break;
            }
            _actionState = value;
        }
    }

    void Awake()
    {
        inputMappings = new InputMappings();
        inputMappings.Enable();

        //inputMappings.Movement.Jump.performed += _ => return;   // TODO: Implement Jump.
        inputMappings.Movement.Run.started += _ => MoveState = MovementState.Run;
        inputMappings.Movement.Run.canceled += _ => MoveState = MovementState.Jog;
        inputMappings.Weapon.Reload.performed += _ => ActState = ActionState.Reload; // TODO: End state on reload finish.
        inputMappings.Weapon.Shoot.started += _ => ActState = ActionState.Fire;
        inputMappings.Weapon.Shoot.canceled += _ => ActState = ActionState.None;
        inputMappings.Weapon.ADS.started += _ => MoveState = MovementState.ADS;
        inputMappings.Weapon.ADS.canceled += _ => MoveState = MovementState.Jog;
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
        Debug.Log($"Movement State: {MoveState}, Action State {ActState}");
    }
}
