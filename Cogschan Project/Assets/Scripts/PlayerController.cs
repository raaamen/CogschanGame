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
    private InputMapping inputMappings;

    private bool inputRun = false;
    private bool inputFire = false;
    private bool inputAim = false;

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
        inputMappings = new InputMapping();
        inputMappings.Enable();

        //inputMappings.Movement.Jump.performed += _ => return;   // TODO: Implement Jump.
        inputMappings.Movement.Run.started += _ => inputRun = true;
        inputMappings.Movement.Run.canceled += _ => inputRun = false;
        inputMappings.Weapon.Reload.performed += _ => ActState = ActionState.Reload; // TODO: End state on reload finish.
        inputMappings.Weapon.Shoot.started += _ => inputFire = true;
        inputMappings.Weapon.Shoot.canceled += _ => inputFire = false;
        inputMappings.Weapon.Aim.started += _ => inputAim = true;
        inputMappings.Weapon.Aim.canceled += _ => inputAim = false;
    }

    // TODO: make this seperate methods?
    void Update()
    {
        if (inputRun)
            MoveState = MovementState.Run;
        else if (MoveState == MovementState.Run)
            MoveState = MovementState.Jog;

        if (inputFire)
            ActState = ActionState.Fire;
        else if (ActState == ActionState.Fire)
            ActState = ActionState.None;

        if (inputAim)
            MoveState = MovementState.ADS;
        else if (MoveState == MovementState.ADS)
            MoveState = MovementState.Jog;
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
