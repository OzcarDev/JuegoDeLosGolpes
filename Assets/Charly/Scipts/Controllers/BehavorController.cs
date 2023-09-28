using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehavorController : MonoBehaviour
{
    public List<Steering> behavors;
    public float maxSpeed = 5f;
    public float maxForce = 5f;

    private Vector3 _totalForce;
    private Vector3 _velocity;

    private void FixedUpdate()
    {
        _totalForce = Vector3.zero;
        foreach(var behavor in behavors)
        {
            behavor.Velocity = _velocity;
            behavor.Position = transform.position;
            _totalForce += LimitVector(behavor.GetForce(), maxForce);
        }

        _velocity = LimitVector(_velocity + _totalForce, maxSpeed);
        transform.position += _velocity * Time.deltaTime;
    }

    private Vector3 LimitVector(Vector3 force, float limit)
    {
        return Vector3.ClampMagnitude(force,limit);
    }
}
