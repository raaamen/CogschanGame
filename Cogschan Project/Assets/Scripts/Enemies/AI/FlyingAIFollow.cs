using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingAIFollow : MonoBehaviour
{
    public float TopSpeed;
    public float Acceleration;

    public float PreferredOrbitDistance;
    public float MaxOrbitDistance;
    public float PreferredHeight;

    public Transform Target;

    public LayerMask LayerMask;

    private Rigidbody _rb;
    private float _speed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _speed = 0;
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, Target.position) <= PreferredOrbitDistance) 
        {
            _speed = Mathf.Max(0, _speed - Acceleration * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, Target.position) >= MaxOrbitDistance)
        {
            _speed = Mathf.Min(TopSpeed, _speed + Acceleration * Time.deltaTime);
        }
        Vector3 dir = Vector3.Normalize(Target.position - transform.position);
        _rb.MovePosition(transform.position + dir * _speed * Time.deltaTime);

    }
}
