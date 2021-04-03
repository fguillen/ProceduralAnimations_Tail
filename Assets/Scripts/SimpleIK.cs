using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// From here: https://www.alanzucconi.com/2018/05/02/ik-2d-2/
public class SimpleIK : MonoBehaviour
{
    [Header("Joints")]
    [SerializeField] Transform joint0;
    [SerializeField] Transform joint1;
    [SerializeField] Transform hand;

    [Header("Target")]
    [SerializeField] Transform target;

    float length0;
    float length1;

    void Start()
    {
        CalculateLengths();
    }

    void Update()
    {
        MoveArms();
    }


    void CalculateLengths()
    {
        length0 = Vector3.Distance(joint0.position, joint1.position);
        length1 = Vector3.Distance(joint1.position, hand.position);
    }

    void MoveArms()
    {
        float joint0Angle;
        float joint1Angle;

        // Distance from joint0 to target
        float length2 = Vector3.Distance(joint0.position, target.position);

        // Angle from joint0 and target
        Vector2 diff = target.position - joint0.position;
        float atan = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        // If not reachable we stretch the arm
        if(length0 + length1 < length2)
        {
            joint0Angle = atan;
            joint1Angle = 0f;
        }
        else
        {
            // Inner angle alpha
            float cosAngle0 = ((length2 * length2) + (length0 * length0) - (length1 * length1)) / (2 * length2 * length0);
            float angle0 = Mathf.Acos(cosAngle0) * Mathf.Rad2Deg;

            // Inner angle beta
            float cosAngle1 = ((length1 * length1) + (length0 * length0) - (length2 * length2)) / (2 * length1 * length0);
            float angle1 = Mathf.Acos(cosAngle1) * Mathf.Rad2Deg;

            // Unity reference frame
            joint0Angle = atan - angle0;
            joint1Angle = 180f - angle1;
        }

        // Execute rotations
        Vector3 euler0 = joint0.transform.localEulerAngles;
        euler0.z = joint0Angle;
        joint0.transform.localEulerAngles = euler0;

        Vector3 euler1 = joint1.transform.localEulerAngles;
        euler1.z = joint1Angle;
        joint1.transform.localEulerAngles = euler1;
    }



}
