using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private MovementState state;

    // Start is called before the first frame update
    void Awake()
    {
        state = new MovementStateDefault();
        state.InitController(this);
    }

    // Update is called once per frame
    void Update()
    {
        state.HandleMovement();
        //gravity
    }

    public void SetState(MovementState state)
    {
        this.state = state;
    }
}
