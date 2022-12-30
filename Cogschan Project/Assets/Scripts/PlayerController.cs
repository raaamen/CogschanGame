using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

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

    private StarterAssetsInputs inputs;

    public Gun Gun;

    // Jump is not part of movement states.
    public MovementState MoveState
    {
        get { return _movementState; }
        private set
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
    public ActionState ActState
    {
        get { return _actionState; }
        private set
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

        inputMappings.Movement.Run.started += _ => inputRun = true;
        inputMappings.Movement.Run.canceled += _ => inputRun = false;
        inputMappings.Weapon.Reload.performed += _ => Gun.Reload();
        inputMappings.Weapon.Shoot.started += _ => inputFire = true;
        inputMappings.Weapon.Shoot.canceled += _ => inputFire = false;
        inputMappings.Weapon.Aim.started += _ => inputAim = true;
        inputMappings.Weapon.Aim.canceled += _ => inputAim = false;

        inputs = GetComponent<StarterAssetsInputs>();
    }

    // TODO: make this seperate methods?
    void Update()
    {
        // Set the movement and action states.
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

        if (Gun.IsReloading)
            ActState = ActionState.Reload;
        else if (ActState == ActionState.Reload)
            ActState = ActionState.None;

        if (ActState == ActionState.Fire)
        {
            if (MoveState == MovementState.ADS)
                Gun.ADSFire();
            else
                Gun.HipFire();
        }

        // Use the input and states to interact with the StarterAssestsInputs and the ThirdPersonShooterController.
        //Debug.Log($"Movement State: {MoveState}, Action State {ActState}, Ammo Count: {Gun.Ammo}|{Gun.ReserveAmmo}");
        inputs.MoveInput(inputMappings.Movement.Move.ReadValue<Vector2>());
        inputs.SprintInput(MoveState == MovementState.Run);
        inputs.AimInput(MoveState == MovementState.ADS);

    }

    private void OnEnable()
    {
        inputMappings.Enable();
    }

    private void OnDisable()
    {
        inputMappings.Disable();
    }

    /* Wasn't really sure why this is here
    private void FixedUpdate()
    {
        Vector2 dir = inputMappings.Movement.Move.ReadValue<Vector2>();
        
    }*/
}