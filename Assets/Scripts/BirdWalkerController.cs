using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdWalkerController : MonoBehaviour
{
    [SerializeField] Transform bird;
    [SerializeField] Transform footPointRear;
    [SerializeField] Transform footPointFront;
    [SerializeField] Transform ikEffectorRear;
    [SerializeField] Transform ikEffectorFront;
    [SerializeField] Transform ikTargetRear;
    [SerializeField] Transform ikTargetFront;

    [SerializeField] float maxTargetDistance;


    // Update is called once per frame
    void Update()
    {
        CheckIfRearTargetShouldMove();
        CheckIfFrontTargetShouldMove();
    }

    void CheckIfRearTargetShouldMove()
    {
        if(Vector3.Distance(ikEffectorRear.position, footPointRear.position) > maxTargetDistance)
            ikTargetRear.position = footPointRear.position;
    }

    void CheckIfFrontTargetShouldMove()
    {
        if(Vector3.Distance(ikEffectorFront.position, footPointFront.position) > maxTargetDistance)
            ikTargetFront.position = footPointFront.position;
    }
}
