using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{

    public GameObject[] waypoints;
    int currentWaypoint = 0;
    public float rotationSpeed;
    public float moveSpeed;
    public float waypointDistance = 1;

    public float hoverHeight = 3f;
    public float heightSmooth = 10f;
    private Vector3 _prevUp;
    public float pitchSmooth = 5f;
    private float _smoothY;
    private float _currentSpeed;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //-------------------------------------------------------------------


       // Debug.Log(Vector3.Distance(waypoints[currentWaypoint].transform.position, transform.position));
        if(Vector3.Distance(waypoints[currentWaypoint].transform.position, transform.position) < 1)
        {
            currentWaypoint++;
            if(currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }
       // Debug.Log(currentWaypoint);
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * moveSpeed);

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
