using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedometer : MonoBehaviour
{

    public const float MAX_SPEED_ANGLE = 0;
    public const float ZERO_SPEED_ANGLE = 180;

    public Transform needleTransform;

    public float speedMax;
    public float speed;

    // Start is called before the first frame update
    void Awake()
    {
        needleTransform = transform.Find("needle");

        speed = 0f;
        speedMax = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        speed += 30f * Time.deltaTime;
        if (speed > speedMax) speed = speedMax;
        float SpeedRotation = GetSpeedrotation();
        Debug.Log(SpeedRotation);
        transform.eulerAngles = new Vector3(0, 0, SpeedRotation);
    }

    public float GetSpeedrotation()
    {
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        float speedNormalized = speed / speedMax;

        return ZERO_SPEED_ANGLE - speedNormalized * totalAngleSize;
    }
}
