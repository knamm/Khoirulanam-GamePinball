using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float maxSpeed;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_rb.velocity.magnitude > maxSpeed)
        {
            _rb.velocity = _rb.velocity.normalized * maxSpeed;
        }
    }
}
