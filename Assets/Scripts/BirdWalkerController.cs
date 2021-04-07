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

    [SerializeField] float feetSpeed = 1.0f;

    [SerializeField] float maxTargetDistance;

    bool _movingRear = false;
    bool _movingFront = false;


    // Update is called once per frame
    void Update()
    {
        if(!_movingRear)
            CheckIfRearTargetShouldMove();

        if(!_movingFront)
            CheckIfFrontTargetShouldMove();

        if(_movingRear)
            MoveRear();

        if(_movingFront)
            MoveFront();
    }

    void MoveRear()
    {
        ikTargetRear.position = Vector3.MoveTowards(ikTargetRear.position, footPointRear.position, feetSpeed);

        if(ikTargetRear.position == footPointRear.position)
            _movingRear = false;
    }

    void MoveFront()
    {
        ikTargetFront.position = Vector3.MoveTowards(ikTargetFront.position, footPointFront.position, feetSpeed);

        if(ikTargetFront.position == footPointFront.position)
            _movingFront = false;
    }

    void CheckIfRearTargetShouldMove()
    {
        if(Vector3.Distance(ikEffectorRear.position, footPointRear.position) > maxTargetDistance)
            _movingRear = true;
    }

    void CheckIfFrontTargetShouldMove()
    {
        if(Vector3.Distance(ikEffectorFront.position, footPointFront.position) > maxTargetDistance)
            _movingFront = true;
    }
}
