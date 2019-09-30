using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFloatController : MonoBehaviour
{
    public float forwardAcceleration = 100f;
    public float forwardMaxSpeed = 200f;
    public float brakeSpeed = 200f;
    public float turnSpeed = 50f;

    public float hoverHeight = 3f;
    public float heightSmooth = 10f;
    public float pitchSmooth = 5f;

    private Vector3 _prevUp;
    public float yaw;
    private float _smoothY;
    private float _currentSpeed;

    public GameObject[] waypoints;
    int currentWaypoint = 0;
    public float rotationSpeed;
    public float moveSpeed;
    public float waypointDistance = 1;

    void Start()
    {
        
    }

    void Update()
    {
        // if (Input.GetKey(KeyCode.W))
        //{
        //     _currentSpeed += (_currentSpeed >= forwardMaxSpeed) ? 0f : forwardAcceleration * Time.deltaTime;
        // }
        // else
        //{
        //    if (_currentSpeed > 0)
        //        _currentSpeed -= brakeSpeed * Time.deltaTime;
        //    else
        //    {
        //        _currentSpeed = 0f;
        //    }
        // }
        if (Vector3.Distance(waypoints[currentWaypoint].transform.position, transform.position) < .01f)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }
        Debug.Log(waypoints[currentWaypoint]);
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * moveSpeed);

        yaw += turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        _prevUp = transform.up;
        transform.rotation = Quaternion.Euler(0, yaw,0);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -_prevUp, out hit))
        {
            Debug.DrawLine(transform.position, hit.point);

            Vector3 desired_up = Vector3.Lerp(_prevUp, hit.normal, Time.deltaTime * pitchSmooth);
            Quaternion tilt = Quaternion.FromToRotation(transform.up, desired_up);
            transform.rotation = tilt * transform.rotation;

            _smoothY = Mathf.Lerp(_smoothY, hoverHeight - hit.distance, Time.deltaTime * heightSmooth);
            transform.localPosition += _prevUp * _smoothY;
        }

        transform.position += transform.forward * (_currentSpeed * Time.deltaTime);

    }


}
