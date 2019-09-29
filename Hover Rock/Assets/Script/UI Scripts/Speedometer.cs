using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedometer : MonoBehaviour
{

    public const float MAX_SPEED_ANGLE = 0;
    public const float ZERO_SPEED_ANGLE = 180;

    public Transform needleTransform;

    public float speedMax;
    public float speedMin;
    public float speed;
    public float fakeSpeedRate = 100;

    // Start is called before the first frame update
    void Awake()
    {
        needleTransform = transform.Find("needle");

        speedMin = 0f;
        speed = 0f;
        speedMax = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            speed += fakeSpeedRate * Time.deltaTime;
        }
        else
        {
            speed -= fakeSpeedRate * Time.deltaTime;
        }

        if (speed > speedMax) speed = speedMax;
        if (speed < speedMin) speed = speedMin;
        float SpeedRotation = GetSpeedrotation();
        transform.eulerAngles = new Vector3(0, 0, SpeedRotation);
    }

    public float GetSpeedrotation()
    {
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        float speedNormalized = speed / speedMax;

        return ZERO_SPEED_ANGLE - speedNormalized * totalAngleSize;
    }
}
