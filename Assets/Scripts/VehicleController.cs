using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VehicleController : MonoBehaviour
{
    public float MAX_SPEED = 10f;
    public float acceleration = 10f;
    public float brakesDeccel = 9f;

    public float turnAcceleration = 2f;
    public float turnAccelerationLow = 0.01f;
    public float turnAccelerationHigh = 10f;

    public float turnDampening = 0.9f;

    public bool DRAW_DEBUG;

    private Rigidbody _rigidbody;
    private float _turnVel = 0f;

    private Vector3 _direction;


    private Vector3 _momentum;
    private Vector3 _velocity;
    private Vector3 _acceleration;
    private Vector3 _heading;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // ALL GAS, NO BRAKES
        _rigidbody.AddRelativeForce(Vector3.forward * acceleration, ForceMode.Force);


        float currVelMag = _rigidbody.velocity.magnitude;


        float MIN_SPEED = MAX_SPEED * 0.5f;

        float currTurnAccel = turnAcceleration;
        float currTurnDamp = turnDampening;
        // OK, BRAKES I GUESS. BUT STILL ALL GAS
        Vector3 accel = Vector3.zero;
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // the closer we are to max speed, the more effective braking is,
            // but by the time we are slower, we are barely braking
            float brakes = Easing.RangeMap(currVelMag, MIN_SPEED, MAX_SPEED, 0f, brakesDeccel, Easing.SmoothStop3);

            accel = Vector3.back * brakes;

            _rigidbody.AddRelativeForce(accel, ForceMode.Force);
            DrawAccel(transform.TransformVector(accel));

            // as soon as start braking, turn speed improves
            // turn speed gets ludicrous the slower we are
            currTurnAccel = Easing.RangeMap(currVelMag, MIN_SPEED, MAX_SPEED, turnAcceleration * turnAccelerationLow, turnAcceleration * turnAccelerationHigh, Easing.SmoothStop3);

            // slower we're going while braking, the closer turn decay is to 1f, 
            // meaning no decay/damp
            currTurnDamp = Easing.RangeMap(currVelMag, MIN_SPEED, MAX_SPEED, 0.5f, currTurnDamp, Easing.SmoothStart3);
        }

        // stop spinning from collisions - could also make nonlinear thing
        _rigidbody.angularVelocity *= 0.9f;

        // 
        float turnDir = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            turnDir -= 1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            turnDir += 1f;
        }

        _turnVel += turnDir * currTurnAccel * Time.deltaTime;
        // if(!Input.GetKey(KeyCode.RightArrow) && ! Input.GetKey(KeyCode.LeftArrow))
        {
            _turnVel *= currTurnDamp;
        }

        var nextVelocity = _rigidbody.velocity;
        var turnRot = Quaternion.AngleAxis(_turnVel, Vector3.up);
        nextVelocity = turnRot * nextVelocity;

        _rigidbody.rotation *= turnRot;


        if (nextVelocity.sqrMagnitude > MAX_SPEED * MAX_SPEED)
        {
            nextVelocity = nextVelocity.normalized * MAX_SPEED;
        }



        // 1f = completely the same, 0f orthogonal, -1f opposite
        // var fwVsVel = Mathf.Abs(Vector3.Dot(nextVelocity.normalized, transform.forward));
        // var t = Easing.RangeMap(fwVsVel, 0.6f, 0.9f, Easing.Linear);
        // nextVelocity *= t;

        _rigidbody.velocity = nextVelocity;
        DrawVelocity(_rigidbody.velocity);
        // DrawForward(transform.forward);
        DrawForward(_rigidbody.rotation * Vector3.forward);


        // transform.forward = _rigidbody.velocity;
    }

    private void DrawAccel(Vector3 accel)
    {
        if (!DRAW_DEBUG) { return; }
        if (accel.sqrMagnitude > 0.001f)
        {
            Debug.DrawRay(transform.position, transform.position + accel, Color.red, 0f, false);
        }
    }

    private void DrawVelocity(Vector3 velocity)
    {
        if (!DRAW_DEBUG) { return; }
        if (velocity.sqrMagnitude > 0.001f)
        {
            Debug.DrawRay(transform.position, transform.position + velocity, Color.blue, 0f, false);
        }
    }

    private void DrawForward(Vector3 forward)
    {
        if (!DRAW_DEBUG) { return; }
        if (forward.sqrMagnitude > 0.001f)
        {
            Debug.DrawRay(transform.position, transform.position + forward, Color.green, 0f, false);
        }
    }
}
