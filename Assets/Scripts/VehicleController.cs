using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VehicleController : MonoBehaviour
{
    public float MAX_SPEED = 10f;
    public float acceleration = 10f;

    public float turnAcceleration = 2f;
    public float turnDampening = 0.9f;

    private Rigidbody _rigidbody;
    private float _turnVel = 0f;

    private Vector3 _direction;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            var force = Vector3.forward * acceleration;
            _rigidbody.AddRelativeForce(force, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            var force = Vector3.back * acceleration;
            _rigidbody.AddRelativeForce(force, ForceMode.Force);
        }


        float turnDir = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            turnDir -= 1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            turnDir += 1f;
        }

        _turnVel += turnDir * turnAcceleration * Time.deltaTime;
        _turnVel *= turnDampening;

        var nextVelocity = _rigidbody.velocity;
        var turnRot = Quaternion.AngleAxis(_turnVel, Vector3.up);
        nextVelocity = turnRot * nextVelocity;

        if (nextVelocity.sqrMagnitude > MAX_SPEED * MAX_SPEED)
        {
            nextVelocity = nextVelocity.normalized * MAX_SPEED;
        }



        // 1f = completely the same, 0f orthogonal, -1f opposite
        // var fwVsVel = Mathf.Abs(Vector3.Dot(nextVelocity.normalized, transform.forward));
        // var t = Easing.RangeMap(fwVsVel, 0.6f, 0.9f, Easing.Linear);
        // nextVelocity *= t;

        _rigidbody.velocity = nextVelocity;

        // transform.forward = _rigidbody.velocity;
    }
}
